using System.Diagnostics;
using JetBrains.Annotations;
using OneOf;

namespace NexusMods.Abstractions.Jobs;

/// <summary>
/// A base implementation of <see cref="IJobWorker"/>.
/// </summary>
[PublicAPI]
public abstract class AJobWorker : IJobWorker
{
    /// <summary>
    /// Executes the job.
    /// </summary>
    protected abstract Task<JobResult> ExecuteAsync(AJob job, CancellationToken cancellationToken);

    private record struct Paused;

    private async Task<OneOf<JobResult, Paused>> ExecuteAsyncInner(AJob job, CancellationToken cancellationToken)
    {
        try
        {
            var result = await ExecuteAsync(job, cancellationToken);
            return OneOf<JobResult, Paused>.FromT0(result);
        }
        catch (TaskCanceledException)
        {
            if (job.IsRequestingPause)
            {
                job.IsRequestingPause = false;
                return new Paused();
            }

            return JobResult.CreateCancelled();
        }
        catch (Exception e)
        {
            return JobResult.CreateFailed(e);
        }
    }

    protected void SetWorker(AJob job)
    {
        if (job.Worker is null)
        {
            job.SetWorker(this);
            return;
        }

        Debug.Assert(ReferenceEquals(job.Worker, this), "same worker");
    }

    /// <inheritdoc/>
    public ValueTask StartAsync(IJob input, CancellationToken cancellationToken = default)
    {
        if (input is not AJob job) throw new NotSupportedException();
        cancellationToken.ThrowIfCancellationRequested();

        SetWorker(job);
        if (job.Status == JobStatus.None)
        {
            job.SetStatus(JobStatus.Created);
        }

        if (job.Status == JobStatus.Paused)
        {
            Debug.Assert(job.Task is null || job.Task.IsCompleted, "task should've completed");
            job.Task = null;
            var didReset = job.CancellationTokenSource.TryReset();
            Debug.Assert(didReset, "reset should work");
        }

        job.SetStatus(JobStatus.Running);

        Task<OneOf<JobResult, Paused>> task;
        try
        {
            task = ExecuteAsyncInner(job, job.CancellationTokenSource.Token);
        }
        catch (Exception e)
        {
            // synchronous or async startup exception
            job.SetResult(JobResult.CreateFailed(e), inferStatus: true);
            return ValueTask.CompletedTask;
        }

        // task might complete synchronously
        if (task.IsCompleted)
        {
            Debug.Assert(task.IsCompletedSuccessfully, "wrapper task should always complete successfully");
            var result = task.Result;
            if (result.IsT0)
            {
                job.SetResult(result.AsT0, inferStatus: true);
            }
            else
            {
                job.SetStatus(JobStatus.Paused);
            }

            job.Task = null;
            return ValueTask.CompletedTask;
        }

        task.Start();
        job.Task = task;
        return ValueTask.CompletedTask;
    }

    private static JobResult TaskResultToJobResult(Task<JobResult> task)
    {
        if (task.IsCompletedSuccessfully)
        {
            return task.Result;
        }

        if (task.IsCanceled)
        {
            return JobResult.CreateCancelled();
        }

        if (task.IsFaulted)
        {
            return JobResult.CreateFailed(task.Exception);
        }

        throw new UnreachableException();
    }

    /// <inheritdoc/>
    public async ValueTask PauseAsync(IJob input, CancellationToken cancellationToken = default)
    {
        if (input is not AJob job) throw new NotSupportedException();
        cancellationToken.ThrowIfCancellationRequested();
        job.Status.AssertTransition(JobStatus.Paused);

        var tsc = new TaskCompletionSource();
        using var disposable = job.ObservableStatus.Subscribe(status =>
        {
            if (status == JobStatus.Paused) tsc.SetResult();
        });

        job.IsRequestingPause = true;
        await job.CancellationTokenSource.CancelAsync();
        await tsc.Task.WaitAsync(cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async ValueTask CancelAsync(IJob input, CancellationToken cancellationToken = default)
    {
        if (input is not AJob job) throw new NotSupportedException();
        cancellationToken.ThrowIfCancellationRequested();
        job.Status.AssertTransition(JobStatus.Cancelled);

        var tsc = new TaskCompletionSource();
        using var disposable = job.ObservableStatus.Subscribe(status =>
        {
            if (status == JobStatus.Cancelled) tsc.SetResult();
        });

        job.IsRequestingPause = false;
        await job.CancellationTokenSource.CancelAsync();
        await tsc.Task.WaitAsync(cancellationToken: cancellationToken);
    }
}

[PublicAPI]
public abstract class AJobWorker<TJob> : AJobWorker
    where TJob : AJob
{
    /// <inheritdoc/>
    protected override Task<JobResult> ExecuteAsync(AJob job, CancellationToken cancellationToken)
    {
        if (job is not TJob expectedJob) throw new NotSupportedException();
        return ExecuteAsync(expectedJob, cancellationToken);
    }

    /// <inheritdoc cref="AJobWorker.ExecuteAsync"/>
    protected abstract Task<JobResult> ExecuteAsync(TJob job, CancellationToken cancellationToken);
}

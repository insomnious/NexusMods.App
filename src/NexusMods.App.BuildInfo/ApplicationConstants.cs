﻿using System.Reflection;

namespace NexusMods.App.BuildInfo;

/// <summary>
/// Constants supplied during runtime.
/// </summary>
public static class ApplicationConstants
{
    static ApplicationConstants()
    {
        var attribute = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute));
        if (attribute is AssemblyInformationalVersionAttribute assemblyInformationalVersionAttribute)
        {
            var informationalVersion = assemblyInformationalVersionAttribute.InformationalVersion;
            var sha = GetSha(informationalVersion);
            CommitHash = sha;
        }

        Version = Assembly.GetExecutingAssembly().GetName().Version!;
    }

    private static string? GetSha(string input)
    {
        var span = input.AsSpan();
        var plusIndex = span.IndexOf('+');
        return plusIndex == -1 ? null : span[plusIndex..].ToString();
    }

    /// <summary>
    /// Gets the current Version.
    /// </summary>
    public static Version Version { get; }

    /// <summary>
    /// Gets the hash of the current commit.
    /// </summary>
    public static string? CommitHash { get; }
}


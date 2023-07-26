﻿using System.Buffers;
using NexusMods.Paths;

namespace NexusMods.Networking.HttpDownloader.DTOs;

/// <summary>
/// Used to contain information that will be sent to the write queue.
/// </summary>
struct WriteOrder
{
    public Size Offset;
    public Memory<byte> Data;
    public IMemoryOwner<byte> Owner;
    public ChunkState Chunk;
}

using NexusMods.Abstractions.Games.Trees;
using NexusMods.Abstractions.Installers.DTO;

namespace NexusMods.Abstractions.Games.DTO;

/// <summary>
/// A file tree is a tree that contains all files from a loadout, flattened into a single tree.
/// </summary>
public class FlattenedLoadout : AGamePathNodeTree<ModFilePair>
{
    private FlattenedLoadout(IEnumerable<KeyValuePair<GamePath, ModFilePair>> tree) : base(tree) { }

    /// <summary>
    ///     Creates a tree that contains all files from a loadout, flattened into a single tree.
    /// </summary>
    public static FlattenedLoadout Create(IEnumerable<KeyValuePair<GamePath, ModFilePair>> items) => new(items);
}

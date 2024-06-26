using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using NexusMods.Abstractions.Games.DTO;
using NexusMods.Abstractions.MnemonicDB.Attributes;
using NexusMods.MnemonicDB.Abstractions;
using NexusMods.MnemonicDB.Abstractions.Attributes;
using NexusMods.MnemonicDB.Abstractions.Models;

namespace NexusMods.DataModel.Attributes;

/// <summary>
/// MnemonicDB attributes for the DiskStateTree registry.
/// </summary>b
public static class DiskState
{
    private static readonly string Namespace = "NexusMods.DataModel.DiskStateRegistry";
    
    /// <summary>
    /// The associated game id.
    /// </summary>
    public static readonly GameDomainAttribute Game = new(Namespace, nameof(Game)) { IsIndexed = true, NoHistory = true };
    
    /// <summary>
    /// The game's root folder. Stored as a string, since AbsolutePaths require an IFileSystem, and we don't know or care
    /// what filesystem is being used when reading/writing the data from the database.
    /// </summary>
    public static readonly StringAttribute Root = new(Namespace, nameof(Root)) { IsIndexed = true, NoHistory = true };
    
    /// <summary>
    /// The associated loadout id.
    /// </summary>
    public static readonly ReferenceAttribute Loadout = new(Namespace, nameof(Loadout)) { IsIndexed = true, NoHistory = true };
    
    /// <summary>
    /// The associated transaction id.
    /// </summary>
    public static readonly ReferenceAttribute TxId = new(Namespace, nameof(TxId)) { IsIndexed = true, NoHistory = true };

    /// <summary>
    /// The state of the disk.
    /// </summary>
    public static readonly DiskStateAttribute State = new(Namespace, nameof(State)) { NoHistory = true };

    [PublicAPI]
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    internal class Model(ITransaction tx) : Entity(tx, (byte)IdPartitions.DiskState)
    {
        /// <summary>
        /// The associated game type
        /// </summary>
        public GameDomain Game
        {
            get => Attributes.DiskState.Game.Get(this);
            set => Attributes.DiskState.Game.Add(this, value);
        }
    
        /// <summary>
        /// The associated game root folder
        /// </summary>
        public string Root
        {
            get => Attributes.DiskState.Root.Get(this);
            set => Attributes.DiskState.Root.Add(this, value);
        }
    

        /// <summary>
        /// The associated loadout id.
        /// </summary>
        public EntityId LoadoutId
        {
            get => Loadout.Get(this);
            set => Loadout.Add(this, value);
        }
        
        /// <summary>
        /// The associated transaction id.
        /// </summary>
        public TxId TxId
        {
            get => TxId.From(Attributes.DiskState.TxId.Get(this).Value);
            set => Attributes.DiskState.TxId.Add(this, EntityId.From(value.Value));
        }
        
    
        /// <summary>
        /// The state of the disk.
        /// </summary>
        public NexusMods.Abstractions.DiskState.DiskStateTree DiskState
        {
            get => State.Get(this);
            set => State.Add(this, value);
        }
    }
}

/// <summary>
///     A sibling of <see cref="DiskState"/>, but only for the initial state.
/// </summary>
/// <remarks>
///     We don't want to keep history in <see cref="DiskState"/> as that is only
///     supposed to hold the latest state, so in order to keep things clean,
///     we separated this out to the class.
///
///     This will also make cleaning out loadouts in MneumonicDB easier in the future.
/// </remarks>
public static class InitialDiskState
{
    private static readonly string Namespace = "NexusMods.DataModel.InitialDiskStates";

    /// <summary>
    /// The associated game id.
    /// </summary>
    public static readonly GameDomainAttribute Game = new(Namespace, nameof(Game)) { IsIndexed = true, NoHistory = true };
    
    /// <summary>
    /// The game's root folder. Stored as a string, since AbsolutePaths require an IFileSystem, and we don't know or care
    /// what filesystem is being used when reading/writing the data from the database.
    /// </summary>
    public static readonly StringAttribute Root = new(Namespace, nameof(Root)) { IsIndexed = true, NoHistory = true };

    /// <summary>
    /// The state of the disk.
    /// </summary>
    public static readonly DiskStateAttribute State = new(Namespace, nameof(State)) { NoHistory = true };

    [PublicAPI]
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    internal class Model(ITransaction tx) : Entity(tx)
    {
        /// <summary>
        /// The associated game type
        /// </summary>
        public GameDomain Game
        {
            get => Attributes.InitialDiskState.Game.Get(this);
            set => Attributes.InitialDiskState.Game.Add(this, value);
        }
    
        /// <summary>
        /// The associated game root folder
        /// </summary>
        public string Root
        {
            get => Attributes.InitialDiskState.Root.Get(this);
            set => Attributes.InitialDiskState.Root.Add(this, value);
        }
    
        /// <summary>
        /// The state of the disk.
        /// </summary>
        public NexusMods.Abstractions.DiskState.DiskStateTree DiskState
        {
            get => State.Get(this);
            set => State.Add(this, value);
        }

        /// <summary>
        /// Retracts all of the values of this entity.
        /// </summary>
        /// <remarks>
        ///     Make sure the current model has a Transaction (<see cref="tx"/>) attached
        ///     before calling.
        /// </remarks>
        public void AddRetractToCurrentTx()
        {
            Debug.Assert(Tx != null, "Transaction should be set on `this` item.");
            InitialDiskState.Game.Retract(this);
            InitialDiskState.Root.Retract(this);
            State.Retract(this);
        }
    }
}

using Content.Server.Chat.Systems;
using Content.Shared.Chat.Prototypes;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.EntityEffects.Effects;

/// <summary>
///     Tries to force someone to emote (scream, laugh, etc).
/// </summary>
[UsedImplicitly]
public sealed partial class Emote : EntityEffect
{
    [DataField("emote", customTypeSerializer: typeof(PrototypeIdSerializer<EmotePrototype>))]
    public string? EmoteId;

    [DataField]
    public bool ShowInChat;

    // JUSTIFICATION: Emoting is flavor, so same reason popup messages are not in here.
    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => null;

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (EmoteId == null)
            return;

        var chatSys = args.EntityManager.System<ChatSystem>();
        if (ShowInChat)
<<<<<<< HEAD:Content.Server/Chemistry/ReagentEffects/Emote.cs
            chatSys.TryEmoteWithChat(args.SolutionEntity, EmoteId, ChatTransmitRange.GhostRangeLimit);
=======
            chatSys.TryEmoteWithChat(args.TargetEntity, EmoteId, ChatTransmitRange.GhostRangeLimit, forceEmote: Force);
>>>>>>> Upstream:Content.Server/EntityEffects/Effects/Emote.cs
        else
            chatSys.TryEmoteWithoutChat(args.TargetEntity, EmoteId);

    }
}

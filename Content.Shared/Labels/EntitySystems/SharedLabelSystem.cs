using Content.Shared.Examine;
using Content.Shared.Labels.Components;
using Robust.Shared.Utility;

namespace Content.Shared.Labels.EntitySystems;

public abstract partial class SharedLabelSystem : EntitySystem
{
    [Dependency] protected readonly NameModifierSystem NameMod = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<LabelComponent, MapInitEvent>(OnLabelCompMapInit);
        SubscribeLocalEvent<LabelComponent, ExaminedEvent>(OnExamine);
    }

    private void OnLabelCompMapInit(EntityUid uid, LabelComponent component, MapInitEvent args)
    {
        if (!string.IsNullOrEmpty(component.CurrentLabel))
        {
            component.CurrentLabel = Loc.GetString(component.CurrentLabel);
            Dirty(uid, component);
        }

        NameMod.RefreshNameModifiers(uid);
    }

    public virtual void Label(EntityUid uid, string? text, MetaDataComponent? metadata = null, LabelComponent? label = null){}

    private void OnExamine(EntityUid uid, LabelComponent? label, ExaminedEvent args)
    {
        if (!Resolve(uid, ref label))
            return;

        if (label.CurrentLabel == null)
            return;

        var message = new FormattedMessage();
        message.AddText(Loc.GetString("hand-labeler-has-label", ("label", label.CurrentLabel)));
        args.PushMessage(message);
    }
}

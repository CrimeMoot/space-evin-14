using Content.Shared.Actions;
<<<<<<< HEAD:Content.Shared/Evin/Eye/NightVision/Components/NightVisionComponent.cs
using Content.Shared.Evin.Eye.NightVision.Systems;
=======
using Content.Shared.Backmen.Eye.NightVision.Systems;
using Robust.Shared.Audio;
>>>>>>> 0d76827790 (fix PNV):Content.Shared/Backmen/Eye/NightVision/Components/NightVisionComponent.cs
using Robust.Shared.GameStates;

namespace Content.Shared.Evin.Eye.NightVision.Components;

[RegisterComponent]
[NetworkedComponent, AutoGenerateComponentState]
[Access(typeof(NightVisionSystem))]
public sealed partial class NightVisionComponent : Component
{
    [ViewVariables(VVAccess.ReadWrite), DataField("isOn"), AutoNetworkedField]
    public bool IsNightVision;

    [DataField("color")]
    public Color NightVisionColor = new Color(0.9f, 0.9f, 0.9f, 0.5f);

    [DataField]
    public bool IsToggle = false;

    [DataField] public EntityUid? ActionContainer;

    [Access(Other = AccessPermissions.ReadWriteExecute)]
    public bool DrawShadows = false;

    [Access(Other = AccessPermissions.ReadWriteExecute)]
    public bool GraceFrame = false;

    [DataField("playSoundOn")]
    public bool PlaySoundOn = true;
    public SoundSpecifier OnOffSound = new SoundPathSpecifier("/Audio/Backmen/Misc/night-vision-sound-effect_E_minor.ogg");
}

public sealed partial class NVInstantActionEvent : InstantActionEvent { }

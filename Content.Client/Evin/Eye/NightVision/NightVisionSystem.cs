using Content.Client.Overlays;
using Content.Shared.GameTicking;
<<<<<<< HEAD:Content.Client/Evin/Eye/NightVision/NightVisionSystem.cs
using Content.Shared.Evin.Eye.NightVision.Components;
=======
using Content.Shared.Backmen.Eye.NightVision.Components;
using Content.Shared.Inventory.Events;
>>>>>>> 0d76827790 (fix PNV):Content.Client/Backmen/Eye/NightVision/NightVisionSystem.cs
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Player;

namespace Content.Client.GG.Eye.NightVision;

public sealed class NightVisionSystem : EquipmentHudSystem<NightVisionComponent>
{
    [Dependency] private readonly IOverlayManager _overlayMan = default!;
    [Dependency] private readonly ILightManager _lightManager = default!;


    private NightVisionOverlay _overlay = default!;

    public override void Initialize()
    {
        base.Initialize();

        _overlay = new(Color.Green);
    }

    protected override void UpdateInternal(RefreshEquipmentHudEvent<NightVisionComponent> component)
    {
        base.UpdateInternal(component);

        foreach (var comp in component.Components)
        {
            _overlay.NightvisionColor = comp.NightVisionColor;
        }
        if (!_overlayMan.HasOverlay<NightVisionOverlay>())
        {
            _overlayMan.AddOverlay(_overlay);
        }
        _lightManager.DrawLighting = false;
    }

    protected override void DeactivateInternal()
    {
        base.DeactivateInternal();
        _overlayMan.RemoveOverlay(_overlay);
        _lightManager.DrawLighting = true;
    }
}

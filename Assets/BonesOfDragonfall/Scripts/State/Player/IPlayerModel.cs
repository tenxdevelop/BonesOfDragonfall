/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public interface IPlayerModel : IEntityStateModel<PlayerData>
    {
        ReactiveProperty<float> HealthPoint { get; }
    }
}
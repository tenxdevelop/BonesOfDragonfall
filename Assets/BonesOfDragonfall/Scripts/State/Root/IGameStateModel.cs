/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public interface IGameStateModel
    {
        ReactiveCollection<IEntityStateModel> Entities { get; }

        int GetEntityId();
    }
}
/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive;
using SkyForge.Proxy;
using UnityEngine;

namespace BonesOfDragonfall
{
    public interface IEntityStateModel<TEntityState> : IEntityStateModel, IProxy<TEntityState> where TEntityState : EntityStateData
    {
        
    }

    public interface IEntityStateModel
    {
        ReactiveProperty<Vector3> Position { get; }
        EntityType EntityType { get; }
        int UniqueId { get; }
        string ConfigId { get; }
    }
}
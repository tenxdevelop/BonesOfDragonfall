/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public interface IEntityFactoryService : IDisposable
    {
        public IEntityStateModel CreateEntityModel(EntityStateData entityStateData);
        
        public EntityStateData GetEntityStateData(IEntityStateModel entityStateModel);
        
    }
}
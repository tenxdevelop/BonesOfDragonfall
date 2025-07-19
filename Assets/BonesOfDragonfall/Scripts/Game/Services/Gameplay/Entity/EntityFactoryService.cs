/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public class EntityFactoryService : IEntityFactoryService
    {
        
        public IEntityStateModel CreateEntityModel(EntityStateData entityStateData)
        {
            switch (entityStateData.entityType)
            {
                case EntityType.Player:
                    //var playerModel = new PlayerModel(entityStateData as PlayerData);
                    //return playerModel;
                    return null;
                default:
                    throw new NotImplementedException($"not implemented create factory method for entity type: {entityStateData.entityType}");
            }
        }
        
        public EntityStateData GetEntityStateData(IEntityStateModel entityStateModel)
        {
            switch (entityStateModel.EntityType)
            {
                case EntityType.Player:
                    //var playerModel = entityStateModel as PlayerModel;
                    //return playerModel.OriginState;
                    return null;
                default:
                    throw new NotImplementedException($"not implemented get entity state factory method for entity type: {entityStateModel.EntityType}");
            }
        }
        
        public void Dispose()
        {
            
        }
    }
}
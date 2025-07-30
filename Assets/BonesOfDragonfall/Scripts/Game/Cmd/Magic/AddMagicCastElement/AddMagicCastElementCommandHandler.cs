/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Command;
using System.Linq;

namespace BonesOfDragonfall
{
    public class AddMagicCastElementCommandHandler : ICommandHandler<CmdAddMagicCastElement>
    {
        private GameStateModel _gameStateModel;
        private MagicConfig _magicConfig;
        
        public AddMagicCastElementCommandHandler(GameStateModel gameStateModel, MagicConfig magicConfig)
        {
            _gameStateModel = gameStateModel;
            _magicConfig = magicConfig;
        }
        
        public bool Handle(CmdAddMagicCastElement command)
        {
            var magicEntity = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.EntityId)) as IMagicEntity;

            if (magicEntity == null)
                return false;
            
            if (magicEntity.MagicCast.Count >= _magicConfig.maxLenghtMagicCast)
                return false;

            if (magicEntity.MagicPoint.Value - command.ElementCostOfMagic < 0)
                return false;
            
            magicEntity.MagicPoint.UpdateValue(-command.ElementCostOfMagic);
            
            var isCombineElement = false;
            
            var copyMagicCast = new MagicElementData[magicEntity.MagicCast.Count];
            magicEntity.MagicCast.CopyTo(copyMagicCast, 0);
            
            foreach (var currentMagicElement in copyMagicCast)
            {
                foreach (var combinationMagicElement in _magicConfig.combinationMagicElements)
                {
                    if (combinationMagicElement.IsCombineElement(currentMagicElement.magicElementType, command.AddMagicCastElement))
                    {
                        magicEntity.MagicCast.Remove(currentMagicElement);
                        magicEntity.MagicCast.Add(new MagicElementData()
                        {
                            magicElementType = combinationMagicElement.combinationElementType,
                            costOfMagic = command.ElementCostOfMagic,
                            power = (currentMagicElement.power + command.MagicElementPower) / 2
                        });
                        
                        isCombineElement = true;
                        break;
                    }
                }
                
                if(isCombineElement)
                    break;
            }
            
            if (!isCombineElement)
            {
                magicEntity.MagicCast.Add(new MagicElementData()
                {
                    magicElementType = command.AddMagicCastElement,
                    costOfMagic = command.ElementCostOfMagic,
                    power = command.MagicElementPower
                });
            }

            return true;
        }
    }
}
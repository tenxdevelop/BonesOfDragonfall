/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using System.Linq;

namespace BonesOfDragonfall
{
    public class ResetMagicCastCommandHandler : ICommandHandler<CmdResetMagicCast>
    {
        private GameStateModel _gameStateModel;

        public ResetMagicCastCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdResetMagicCast command)
        {
            var magicEntity = _gameStateModel.Entities.FirstOrDefault(entity => entity.UniqueId.Equals(command.EntityId)) as IMagicEntity;

            if (magicEntity == null)
                return false;
            
            magicEntity.MagicCast.Clear();

            return true;
        }
    }
}
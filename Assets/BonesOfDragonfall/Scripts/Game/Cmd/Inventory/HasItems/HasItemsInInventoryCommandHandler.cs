/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using System.Linq;

namespace BonesOfDragonfall
{
    public class HasItemsInInventoryCommandHandler : ICommandHandler<CmdHasItemsInInventory>
    {

        private GameStateModel _gameStateModel;

        public HasItemsInInventoryCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdHasItemsInInventory command)
        {
            var inventory = _gameStateModel.InventoryMaps.FirstOrDefault(inventory => inventory.OwnerId.Equals(command.InventoryOwnerId));

            if (inventory is null)
                return false;
            
            var itemModel = inventory.Items.FirstOrDefault(item => item.ItemId.Equals(command.ItemId));
            
            return itemModel != null;
        }
    }
}
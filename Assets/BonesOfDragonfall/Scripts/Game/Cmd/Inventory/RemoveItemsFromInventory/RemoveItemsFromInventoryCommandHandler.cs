/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using System.Linq;

namespace BonesOfDragonfall
{
    public class RemoveItemsFromInventoryCommandHandler : ICommandHandler<CmdRemoveItemsFromInventory>
    {
        private GameStateModel _gameStateModel;

        public RemoveItemsFromInventoryCommandHandler(GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
        }
        
        public bool Handle(CmdRemoveItemsFromInventory command)
        {
            var inventory = _gameStateModel.InventoryMaps.FirstOrDefault(inventory => inventory.OwnerId.Equals(command.InventoryOwnerId));

            if (inventory is null)
            {
                command.SetResult(new RemoveItemsFromInventoryResult(command.InventoryOwnerId, command.AmountToRemove, false));
                return false;
            }

            var itemModel = inventory.Items.FirstOrDefault(item => item.ItemId.Equals(command.ItemId));

            if (itemModel is null)
            {
                command.SetResult(new RemoveItemsFromInventoryResult(command.InventoryOwnerId, command.AmountToRemove, false));
                return false;
            }

            if (command.AmountToRemove > itemModel.Amount.Value)
            {
                command.SetResult(new RemoveItemsFromInventoryResult(command.InventoryOwnerId, command.AmountToRemove, false));
                return false;
            }
            
            itemModel.Amount.Value -= command.AmountToRemove;
            
            if (itemModel.Amount.Value == 0)
            {
                inventory.Items.Remove(itemModel);
            }
            
            inventory.InventoryChanged();
            command.SetResult(new RemoveItemsFromInventoryResult(command.InventoryOwnerId, command.AmountToRemove, true));
            return true;
        }
    }
}
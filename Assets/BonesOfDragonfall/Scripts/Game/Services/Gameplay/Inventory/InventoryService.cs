/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class InventoryService : IInventoryService
    {
        public const int PLAYER_INVENTORY_ID = 1;

        private ICommandProcessor _commandProcessor;

        public InventoryService(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }
        
        public void Dispose()
        {
            
        }

        public AddItemsToInventoryResult AddItemsToInventory(int ownerId, int itemId, int amount = 1)
        {
            var command = new CmdAddItemsToInventory(ownerId, itemId, amount);
            _commandProcessor.Process(command);
            
            return command.AddItemsToInventoryResult;
        }
    }
}
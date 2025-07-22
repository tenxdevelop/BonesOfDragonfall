/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdAddItemsToInventory : ICommand
    {
        public readonly int InventoryOwnerId;
        public readonly int ItemId;
        public readonly int AmountToAdd;
        public AddItemsToInventoryResult AddItemsToInventoryResult { get; private set; }

        public CmdAddItemsToInventory(int inventoryOwnerId, int itemId, int amountToAdd)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemId = itemId;
            AmountToAdd = amountToAdd;
        }

        public void SetResult(AddItemsToInventoryResult addItemsToInventoryResult)
        {
            AddItemsToInventoryResult = addItemsToInventoryResult;
        }
    }
}
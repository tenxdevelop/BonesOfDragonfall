/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
    public class CmdRemoveItemsFromInventory : ICommand
    {
        public readonly int InventoryOwnerId;
        public readonly int ItemId;
        public readonly int AmountToRemove;

        public RemoveItemsFromInventoryResult RemoveItemsFromInventoryResult { get; private set; }

        public CmdRemoveItemsFromInventory(int inventoryOwnerId, int itemId, int amountToRemove)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemId = itemId;
            AmountToRemove = amountToRemove;
        }

        public void SetResult(RemoveItemsFromInventoryResult removeItemsFromInventoryResult)
        {
            RemoveItemsFromInventoryResult = removeItemsFromInventoryResult;
        }
    }
}
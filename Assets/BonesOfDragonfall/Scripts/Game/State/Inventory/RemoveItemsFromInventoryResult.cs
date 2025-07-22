/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

namespace BonesOfDragonfall
{
    public readonly struct RemoveItemsFromInventoryResult
    {
        public readonly int OwnerId;
        public readonly int ItemsToRemoveAmount;
        public readonly bool Success;
        
        public RemoveItemsFromInventoryResult(int ownerId, int itemsToRemoveAmount, bool success)
        {
            OwnerId = ownerId;
            ItemsToRemoveAmount = itemsToRemoveAmount;
            Success = success;
        }
    }
}
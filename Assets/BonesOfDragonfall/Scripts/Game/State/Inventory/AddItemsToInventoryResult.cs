/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

namespace BonesOfDragonfall
{
    public readonly struct AddItemsToInventoryResult
    {
        public readonly int OwnerId;
        public readonly int ItemsToAddAmount;
        public readonly bool IsHaveOverload;
        public readonly bool Success;
        
        public AddItemsToInventoryResult(int ownerId, int itemsToAddAmount, bool isHaveOverload, bool success)
        {
            OwnerId = ownerId;
            ItemsToAddAmount = itemsToAddAmount;
            IsHaveOverload = isHaveOverload;
            Success = success;
        }
    }
}
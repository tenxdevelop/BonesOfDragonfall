/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public interface IInventoryService : IDisposable
    {
        AddItemsToInventoryResult AddItemsToInventory(int ownerId, int itemId, int amount = 1);
        RemoveItemsFromInventoryResult RemoveItemsFromInventory(int ownerId, int itemId, int amount = 1);
    }
}
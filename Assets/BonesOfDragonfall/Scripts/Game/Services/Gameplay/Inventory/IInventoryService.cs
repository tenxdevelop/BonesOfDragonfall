/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public interface IInventoryService : IDisposable
    {
        AddItemsToInventoryResult AddItemsToInventory(int ownerId, int itemId, int amount = 1);
    }
}
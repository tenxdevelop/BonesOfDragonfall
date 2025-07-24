/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;

namespace BonesOfDragonfall
{
   public class CmdHasItemsInInventory : ICommand
   {
       public readonly int InventoryOwnerId;
       public readonly int ItemId;

       public CmdHasItemsInInventory(int inventoryOwnerId, int itemId)
       {
           InventoryOwnerId = inventoryOwnerId;
           ItemId = itemId;
       }
   }
}
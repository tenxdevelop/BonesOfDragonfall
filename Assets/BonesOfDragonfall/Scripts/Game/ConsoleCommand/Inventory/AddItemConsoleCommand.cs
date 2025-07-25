/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Services.ConsoleService;
using UnityEngine;
using SkyForge;

namespace BonesOfDragonfall
{
    public class AddItemConsoleCommand : IConsoleCommand
    {
        public string CommandName => "addItem";
        
        public void Process(DIContainer container, string[] parameters)
        {
            var inventoryService = container.Resolve<IInventoryService>();
            var inventoryOwnerId = int.Parse(parameters[0]);
            var itemId = int.Parse(parameters[1]);
            var amount = int.Parse(parameters[2]);
            
            var result = inventoryService.AddItemsToInventory(inventoryOwnerId, itemId, amount);

            if (result.Success)
            {
                Debug.Log($"added item itemId: {itemId}, amount: {amount}");
            }
        }
        
    }
}
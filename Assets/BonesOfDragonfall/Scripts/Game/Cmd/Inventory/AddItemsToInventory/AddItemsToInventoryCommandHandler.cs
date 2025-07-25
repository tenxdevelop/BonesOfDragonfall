/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Command;
using System.Linq;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class AddItemsToInventoryCommandHandler : ICommandHandler<CmdAddItemsToInventory>
    {
        
        private GameStateModel _gameStateModel;
        
        private IItemFactoryService _itemFactoryService;
        private ItemsMap _itemsConfigMap;
        
        public AddItemsToInventoryCommandHandler(GameStateModel gameStateModel, IItemFactoryService itemFactoryService, ISettingsProvider settingsProvider)
        {
            _itemFactoryService = itemFactoryService;
            _gameStateModel = gameStateModel;
            _itemsConfigMap = settingsProvider.GameSettings.itemsMap;
        }
        
        public bool Handle(CmdAddItemsToInventory command)
        {
            if (command.AmountToAdd < 0)
            {
                Debug.Log("don't added item to inventory, amount less 0");
                command.SetResult(new AddItemsToInventoryResult(command.InventoryOwnerId, command.AmountToAdd, false, false));
                return false;
            }

            var inventory = _gameStateModel.InventoryMaps.FirstOrDefault(inventory => inventory.OwnerId.Equals(command.InventoryOwnerId));

            if (inventory is null)
            {
                Debug.Log("inventory not found");
                command.SetResult(new AddItemsToInventoryResult(command.InventoryOwnerId, command.AmountToAdd, false, false));
                return false;
            }

            var itemModel = inventory.Items.FirstOrDefault(itemModel => itemModel.ItemId.Equals(command.ItemId));

            if (itemModel is null)
            {
                itemModel = _itemFactoryService.CreateItemModel(command.ItemId);
                inventory.Items.Add(itemModel);
            }
            
            itemModel.Amount.UpdateValue(command.AmountToAdd);

            var currentWeightInventory = inventory.Items.Sum(currentItemModel =>
            {
                var itemConfig = _itemsConfigMap.GetItemConfig(currentItemModel.ItemId);
                return currentItemModel.Amount.Value * itemConfig.weight;
            });

            var isHaveOverload = currentWeightInventory > inventory.MaxWeight.Value;
            
            var result = new AddItemsToInventoryResult(command.InventoryOwnerId, command.AmountToAdd, isHaveOverload, true);
            
            command.SetResult(result);
            
            return true;
        }
    }
}
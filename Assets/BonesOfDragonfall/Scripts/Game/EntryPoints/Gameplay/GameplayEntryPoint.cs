/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using System.Collections.Generic;
using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using System.Linq;
using UnityEngine;
using SkyForge;

namespace BonesOfDragonfall
{
    public class GameplayEntryPoint : MonoBehaviour, IEntryPoint
    {
        private SingleReactiveProperty<GameplayExitParams> _gameplayExitParams = new();

        private DIContainer _container;
        
        //////// for test /////////
        
        private IPlayerInput _playerInput;
        
        private bool _init;

        private IBinding _inventoryBind;

        private Dictionary<int, IBinding> _itemsBind;

        ///////////////////////////
        
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            _container = parentContainer;

            var gameplayEnterParams = sceneEnterParams.As<GameplayEnterParams>();
            
            var settingsProvider = _container.Resolve<ISettingsProvider>();
            settingsProvider.LoadGameSettings();
            
            GameplayServiceRegister.RegisterServices(_container, gameplayEnterParams, _gameplayExitParams);
            GameplayViewModelRegister.RegisterViewModels(_container, gameplayEnterParams);
            GameplayViewRegister.RegisterViews(_container);
            
            var applicationService = _container.Resolve<ApplicationService>();
            applicationService.HideMouseCursor();
            
            yield return null;
            
            _playerInput = _container.Resolve<IPlayerInput>();
            
            var gameStateModel = _container.Resolve<IGameStateProvider>().StateModel;

            var playerInventory = gameStateModel.InventoryMaps.FirstOrDefault(inventory => inventory.OwnerId.Equals(InventoryService.PLAYER_INVENTORY_ID));

            if (playerInventory != null)
            {
                _inventoryBind = playerInventory.Items.Subscribe(OnItemAdded, OnItemRemoved, OnItemsClear);
            }

            _itemsBind = new Dictionary<int, IBinding>();
            
            _init = true;
        }

        private void OnItemsClear()
        {
            Debug.Log("Inventory cleared");
        }

        private void OnItemRemoved(IItemModel removedItemModel)
        {
            if (_itemsBind.ContainsKey(removedItemModel.ItemId))
            {
                _itemsBind[removedItemModel.ItemId].Dispose();
                _itemsBind.Remove(removedItemModel.ItemId);
            }
            
            Debug.Log("remove item: " + removedItemModel.ItemId);
        }

        private void OnItemAdded(IItemModel newItemModel)
        {
            if (!_itemsBind.ContainsKey(newItemModel.ItemId))
            {
                _itemsBind[newItemModel.ItemId] = newItemModel.Amount.Subscribe(newAmount =>
                {
                    var itemsConfigMap = _container.Resolve<ISettingsProvider>().GameSettings.itemsMap;

                    var itemConfig = itemsConfigMap.GetItemConfig(newItemModel.ItemId);
            
                    Debug.Log($"change amount item: {itemConfig.nameLID} to player inventory new amount: {newAmount}");
                });
            }
            
            var itemsConfigMap = _container.Resolve<ISettingsProvider>().GameSettings.itemsMap;

            var itemConfig = itemsConfigMap.GetItemConfig(newItemModel.ItemId);
            
            Debug.Log($"added item: {itemConfig.nameLID} to player inventory amount: {newItemModel.Amount.Value}");
        }

        private void Update()
        {
            if (_init)
            {
                if (_playerInput.PlayerJumpPressed())
                {
                    var inventoryService = _container.Resolve<IInventoryService>();
                    var result = inventoryService.AddItemsToInventory(InventoryService.PLAYER_INVENTORY_ID, 1, 10);

                    if (result.IsHaveOverload)
                    {
                        Debug.Log("Инвентарь перегружен");
                    }
                }

                if (_playerInput.PlayerCrouchPressed())
                {
                    var inventoryService = _container.Resolve<IInventoryService>();
                    var result = inventoryService.RemoveItemsFromInventory(InventoryService.PLAYER_INVENTORY_ID, 1, 4);

                    if (!result.Success)
                    {
                        Debug.Log("не получилось удалить дерево");
                    }
                }
            }
        }

        private void OnDisable()
        {
            _container.Dispose();
            _inventoryBind.Dispose();

            foreach (var _itemBind in _itemsBind)
            {
                _itemBind.Value.Dispose();
            }
            
            _itemsBind.Clear();
        }
        
        public SkyForge.Reactive.IObservable<SceneExitParams> Run()
        {
            return _gameplayExitParams;
        }
    }
}
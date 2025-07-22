/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using System.Collections;
using SkyForge.Extension;
using SkyForge.Reactive;
using System.Linq;
using UnityEngine;
using SkyForge;
using System;
using System.Collections.Generic;

namespace BonesOfDragonfall
{
    public class GameplayEntryPoint : MonoBehaviour, IEntryPoint
    {
        private SingleReactiveProperty<GameplayExitParams> _gameplayExitParams = new();

        private DIContainer _container;

        private Vector2 _playerMoveDirection = Vector2.zero;

        private bool _playerInventoryIsOverload;

        private IPlayerInput _playerInput;

        private bool _init;

        private IBinding _inventoryBind;

        private Dictionary<int, IBinding> _itemsBind;
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            _container = parentContainer;

            var gameplayEnterParams = sceneEnterParams.As<GameplayEnterParams>();
            
            GameplayServiceRegister.RegisterServices(_container, gameplayEnterParams, _gameplayExitParams);
            GameplayViewModelRegister.RegisterViewModels(_container, gameplayEnterParams);
            GameplayViewRegister.RegisterViews(_container);
            
            var applicationService = _container.Resolve<ApplicationService>();
            applicationService.HideMouseCursor();
            
            yield return null;

            _playerInventoryIsOverload = false;

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
                    var itemsConfigMap = _container.Resolve<IGameConfigProvider>().GameConfig.ItemsMap;

                    var itemConfig = itemsConfigMap.GetItemConfig(newItemModel.ItemId);
            
                    Debug.Log($"change amount item: {itemConfig.nameLID} to player inventory new amount: {newAmount}");
                });
            }
            
            var itemsConfigMap = _container.Resolve<IGameConfigProvider>().GameConfig.ItemsMap;

            var itemConfig = itemsConfigMap.GetItemConfig(newItemModel.ItemId);
            
            Debug.Log($"added item: {itemConfig.nameLID} to player inventory amount: {newItemModel.Amount.Value}");
        }

        private void Update()
        {
            if (_init && _playerInput.PlayerJumpPressed())
            {
                Debug.Log("Try to add wood");
                
                var inventoryService = _container.Resolve<IInventoryService>();
                var result = inventoryService.AddItemsToInventory(InventoryService.PLAYER_INVENTORY_ID, 1, 10);

                if (result.IsHaveOverload && !_playerInventoryIsOverload)
                {
                    Debug.Log("Инвентарь перегружен");
                    _playerInventoryIsOverload = true;
                }
                else
                {
                    _playerInventoryIsOverload = false;
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
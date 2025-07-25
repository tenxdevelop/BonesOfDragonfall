/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Reactive.Extension;
using SkyForge.Reactive;
using SkyForge.MVVM;
using System.Linq;

namespace BonesOfDragonfall
{
    public class UIPlayerInventoryViewModel : IUIPlayerInventoryViewModel
    {
        public ReactiveCollection<IViewModel> Items { get; private set; } = new();
        public ReactiveProperty<bool> IsActiveInventory { get; private set; } = new();

        private readonly IPlayerInventoryInput _playerInventoryInput;
        
        private readonly IBinding _isActiveInventoryBinding;
        private readonly ItemsMap _itemMapConfig;

        private bool _isActiveMouseBefore;
        private float _timeScaleBefore;
        public UIPlayerInventoryViewModel(IInventoryModel playerInventory, ItemsMap itemMapConfig, IPlayerInventoryInput playerInventoryInput, IPlayerInput playerInput, ApplicationService applicationService)
        {
            _playerInventoryInput = playerInventoryInput;
            _itemMapConfig = itemMapConfig;
            
            _isActiveInventoryBinding = IsActiveInventory.Subscribe(inventoryOpen =>
            {
                if (inventoryOpen)
                {
                    _timeScaleBefore = applicationService.StopTimeGame();
                    _isActiveMouseBefore = applicationService.ShowMouseCursor();
                    playerInput.DisablePlayerInput();
                }
                else
                {
                    if(_timeScaleBefore != 0)
                        applicationService.StartTimeGame();
                    
                    if(!_isActiveMouseBefore)
                        applicationService.HideMouseCursor();
                    
                    playerInput.EnablePlayerInput();
                }
            });

            foreach (var item in playerInventory.Items)
            {
                CreateItemViewModel(item);
            }

            playerInventory.Items.Subscribe(OnItemAdded, OnItemRemoved, OnItemsClear);
        }
        
        public void Dispose()
        {
            _isActiveInventoryBinding?.Dispose();
        }

        public void Update(float deltaTime)
        {
            if (_playerInventoryInput.PlayerOpenInventoryPressed())
            {
                IsActiveInventory.Opposed();
            }
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }

        private void CreateItemViewModel(IItemModel itemModel)
        {
            var itemConfig = _itemMapConfig.GetItemConfig(itemModel.ItemId);
            var uIItemViewModel = new UIItemViewModel(itemModel, itemConfig);
            Items.Add(uIItemViewModel);
        }
        
        private void OnItemsClear()
        {
            Items.Clear();
        }

        private void OnItemRemoved(IItemModel itemModelRemoved)
        {
            var removedItemViewModel = Items.FirstOrDefault(viewModel =>
            {
                var itemViewModel = viewModel as IUIItemViewModel;
                return itemViewModel.ItemId.Equals(itemModelRemoved.ItemId);
            });
            
            Items.Remove(removedItemViewModel);
        }

        private void OnItemAdded(IItemModel newItemModel)
        {
            CreateItemViewModel(newItemModel);
        }
    }
}
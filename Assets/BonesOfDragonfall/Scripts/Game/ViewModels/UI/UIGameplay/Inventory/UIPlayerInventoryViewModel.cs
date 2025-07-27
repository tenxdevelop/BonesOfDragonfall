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
        
        public ReactiveProperty<string> CurrentWeight { get; private set; } = new();

        private readonly IInventoryModel _playerInventory;
        private readonly IPlayerInventoryInput _playerInventoryInput;
        private readonly IPlayerInput  _playerInput;
        
        private readonly IBinding _isActiveInventoryBinding;
        private readonly ItemsMap _itemMapConfig;

        private bool _isActiveMouseBefore;
        private bool _isActivePlayerInputBefore;
        private bool _isActivePlayerMovementInputBefore;
        private bool _isActivePlayerMagicInputBefore;
        private float _timeScaleBefore;
        
        public UIPlayerInventoryViewModel(IInventoryModel playerInventory, ItemsMap itemMapConfig, IPlayerInventoryInput playerInventoryInput, 
            IPlayerInput playerInput, IPlayerMagicInput playerMagicInput, ApplicationService applicationService)
        {
            
            _playerInventory = playerInventory;
            
            _playerInventoryInput = playerInventoryInput;
            _playerInput = playerInput;
            
            _itemMapConfig = itemMapConfig;
            
            _isActiveInventoryBinding = IsActiveInventory.Subscribe(inventoryOpen =>
            {
                if (inventoryOpen)
                {
                    _playerInventoryInput.EnablePlayerInventoryInput();
                    
                    _timeScaleBefore = applicationService.StopTimeGame();
                    _isActiveMouseBefore = applicationService.ShowMouseCursor();
                    _isActivePlayerInputBefore = playerInput.DisablePlayerInput();
                    _isActivePlayerMovementInputBefore = playerInput.DisablePlayerMovementInput();
                    _isActivePlayerMagicInputBefore = playerMagicInput.DisablePlayerMagicCastInput();
                }
                else
                {
                    _playerInventoryInput.DisablePlayerInventoryInput();
                    
                    if(_timeScaleBefore != 0)
                        applicationService.StartTimeGame();
                    
                    if(!_isActiveMouseBefore)
                        applicationService.HideMouseCursor();
                    
                    if(_isActivePlayerInputBefore)
                        playerInput.EnablePlayerInput();
                    
                    if(_isActivePlayerMovementInputBefore)
                        playerInput.EnablePlayerMovementInput();
                    
                    if(_isActivePlayerMagicInputBefore)
                        playerMagicInput.EnablePlayerMagicCastInput();
                }
            });

            foreach (var item in _playerInventory.Items)
            {
                CreateItemViewModel(item);
            }
            
            _playerInventory.Items.Subscribe(OnItemAdded, OnItemRemoved, OnItemsClear);

            _playerInventory.InventoryChangedEvent += OnInventoryChanged;
            OnInventoryChanged();
        }
        
        public void Dispose()
        {
            _isActiveInventoryBinding?.Dispose();
            _playerInventory.InventoryChangedEvent -= OnInventoryChanged;
        }

        public void Update(float deltaTime)
        {
            if (_playerInput.PlayerOpenInventoryPressed())
            {
                IsActiveInventory.Value = true;
            }
            
            if (_playerInventoryInput.PlayerCloseInventoryPressed())
            {
                IsActiveInventory.Value = false;
            }
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }

        private void OnInventoryChanged()
        {
            var currentWeight =  _playerInventory.Items.Sum(currentItemModel =>
            {
                var itemConfig = _itemMapConfig.GetItemConfig(currentItemModel.ItemId);
                return currentItemModel.Amount.Value * itemConfig.weight;
            });
            
            CurrentWeight.Value = $"{currentWeight}/{_playerInventory.MaxWeight.Value}";
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
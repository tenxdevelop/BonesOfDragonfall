/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.MVVM.Binders;
using UnityEngine.Events;
using SkyForge.Extension;
using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class UIScreenViewCollectionToUnityEventBinder : ObservableBinder<UIScreenView>
    {

        [SerializeField] private UnityEvent<UIScreenView> _eventAdded;
        [SerializeField] private UnityEvent<UIScreenView> _eventRemoved;
        [SerializeField] private UnityEvent _eventClear;
        
        protected override void OnPropertyChanged(object sender, UIScreenView newValue)
        {
            
        }

        protected override IBinding BindInternal(IViewModel viewModel)
        {
            return BindCollection(PropertyName, viewModel, OnAdded, OnRemoved, OnClear);
        }

        private void OnClear(object sender)
        {
            _eventClear?.Invoke();
        }

        private void OnRemoved(object sender, UIScreenView uIScreenView)
        {
            _eventRemoved?.Invoke(uIScreenView);
        }

        private void OnAdded(object sender, UIScreenView uIScreenView)
        {
            _eventAdded?.Invoke(uIScreenView);
        }
    }
}

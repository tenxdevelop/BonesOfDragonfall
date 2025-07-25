/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using SkyForge.Reactive;
using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class VMCollectionToViewCreationBinder : ObservableBinder<IViewModel>
    {
        [SerializeField] private Transform _viewParent;

        [SerializeField] private View _viewPrefab;

        protected Dictionary<IViewModel, View> _viewMap = new();
        
        protected override void OnPropertyChanged(object sender, IViewModel newValue)
        {
            
        }
        
        protected override IBinding BindInternal(IViewModel viewModel)
        {
            return BindCollection(PropertyName, viewModel, OnAdded, OnRemoved, OnClear);
        }

        private void OnClear(object sender)
        {
            for (var indexChild = 0; indexChild < _viewParent.childCount; indexChild++)
            {
                var childGameObject = _viewParent.GetChild(indexChild).gameObject;
                Destroy(childGameObject);
            }
        }

        protected virtual void OnRemoved(object sender, IViewModel removedViewModel)
        {
            if (_viewMap.TryGetValue(removedViewModel, out View view))
            {
                Destroy(view.gameObject);
                _viewMap.Remove(removedViewModel);
            }
        }

        protected virtual void OnAdded(object sender, IViewModel newViewModel)
        {
            var newView = Instantiate(_viewPrefab, _viewParent);
            newView.Bind(newViewModel);
            _viewMap.Add(newViewModel, newView);
        }
    }
}

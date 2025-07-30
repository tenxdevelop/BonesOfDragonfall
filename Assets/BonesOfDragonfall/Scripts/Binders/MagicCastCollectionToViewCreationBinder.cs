/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using SkyForge.MVVM.Binders;
using SkyForge.Reactive;
using SkyForge.MVVM;
using System.Linq;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class MagicCastCollectionToViewBinder : ObservableBinder<MagicElementData>
    {
        [SerializeField] private List<MagicTypeToSpriteMapping> _mappingSprites = new();
        [SerializeField] private Transform _containerTarget;
        [SerializeField] private UIMagicElementView _magicElementViewPrefab;
        
        private Dictionary<MagicElementData, UIMagicElementView> _magicElementMaps = new();
            
        protected override void OnPropertyChanged(object sender, MagicElementData newValue)
        {
            
        }
        
        protected override IBinding BindInternal(IViewModel viewModel)
        {
            return BindCollection(PropertyName, viewModel, OnAdded, OnRemoved, OnClear);
        }

        private void OnClear()
        {
            foreach (var keyValuePair in _magicElementMaps)
            {
                Destroy(keyValuePair.Value.gameObject);
            }
            _magicElementMaps.Clear();
        }

        private void OnRemoved(MagicElementData removedElementData)
        {
            if (_magicElementMaps.ContainsKey(removedElementData))
            {
                Destroy(_magicElementMaps[removedElementData].gameObject);
                _magicElementMaps.Remove(removedElementData);
            }
        }

        private void OnAdded(MagicElementData newMagicElementData)
        {
            if (_magicElementMaps.ContainsKey(newMagicElementData))
                return;
            
            var view = CreateUIMagicElementView(newMagicElementData);
            _magicElementMaps.Add(newMagicElementData, view);
        }

        private UIMagicElementView CreateUIMagicElementView(MagicElementData magicElementData)
        {
            var view = Instantiate(_magicElementViewPrefab, _containerTarget);
            var magicElementTypeToSpriteMap = _mappingSprites.FirstOrDefault(magicElementTypeToSpriteMap => magicElementTypeToSpriteMap.MagicElementType.Equals(magicElementData.magicElementType));

            if (magicElementTypeToSpriteMap is null)
            {
                Debug.LogWarning($"don't have sprite for magic element type: {magicElementData.magicElementType}");
            }
            else
            {
                view.SetSprite(magicElementTypeToSpriteMap.Sprite);
            }

            return view;
        }
    }
}

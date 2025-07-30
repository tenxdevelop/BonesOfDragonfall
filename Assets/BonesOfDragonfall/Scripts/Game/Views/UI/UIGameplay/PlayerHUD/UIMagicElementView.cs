/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine.UI;
using SkyForge.MVVM;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class UIMagicElementView : View
    {
        [SerializeField] private Image _image;

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}
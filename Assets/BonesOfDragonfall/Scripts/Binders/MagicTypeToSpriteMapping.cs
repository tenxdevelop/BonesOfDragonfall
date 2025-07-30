/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    [Serializable]
    public class MagicTypeToSpriteMapping
    {
        [SerializeField] private MagicElementType _magicElementType;
        [SerializeField] private Sprite _sprite;

        public MagicElementType MagicElementType => _magicElementType;
        public Sprite Sprite => _sprite;
    }
}
/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New combination magic element settings", menuName = "Game settings/Magic/New combination magic element settings")]
    public class CombinationMagicElementConfig : ScriptableObject
    {
        public MagicElementType firstElementType;
        public MagicElementType secondElementType;
        public MagicElementType combinationElementType;

        public bool IsCombineElement(MagicElementType magicElementType, MagicElementType currentElementType)
        {
            return (firstElementType.Equals(magicElementType) && secondElementType.Equals(currentElementType)) ||
                   (firstElementType.Equals(currentElementType) && secondElementType.Equals(magicElementType));
        }
    }
}
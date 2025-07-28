/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New magic settings", menuName = "Game settings/Magic/New magic settings")]
    public class MagicConfig : ScriptableObject
    {
        public List<CombinationMagicElementConfig> combinationMagicElements;
        
        public List<MagicCastConfig> magicCasts;

        public int maxLenghtMagicCast;
    }
}
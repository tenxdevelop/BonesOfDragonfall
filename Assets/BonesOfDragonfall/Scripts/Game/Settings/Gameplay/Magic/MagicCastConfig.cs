/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New magic cast settings", menuName = "Game settings/Magic/New magic cast settings")]
    public class MagicCastConfig : ScriptableObject
    {
        public List<MagicElementType> magicCast;

        public string magic;
    }
}
/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New game config", menuName = "Game configs/new game config")]
    public class GameConfig : ScriptableObject
    {
        public ItemsMap ItemsMap;
    }
}
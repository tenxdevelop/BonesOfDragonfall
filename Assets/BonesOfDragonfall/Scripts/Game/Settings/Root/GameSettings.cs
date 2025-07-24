/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New game settings", menuName = "Game settings/new game settings")]
    public class GameSettings : ScriptableObject
    {
        public ItemsMap itemsMap;

        public PlayerSettings playerSettings;
    }
}
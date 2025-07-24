/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;

namespace BonesOfDragonfall
{
    [CreateAssetMenu(fileName = "New application settings", menuName = "Game settings/New  application settings")]
    public class ApplicationSettings : ScriptableObject
    {
        public int targetFPS;
    }
}
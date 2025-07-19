/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class CmdPlayerRotation : ICommand
    {
        public readonly Vector2 Direction;
        public readonly float SensitivityX;
        public readonly float SensitivityY;
        public readonly int PlayerId;

        public CmdPlayerRotation(Vector2 direction, float sensitivityX, float sensitivityY, int playerId)
        {
            PlayerId = playerId;
            SensitivityX = sensitivityX;
            SensitivityY = sensitivityY;
            Direction = direction;
        }
    }
}
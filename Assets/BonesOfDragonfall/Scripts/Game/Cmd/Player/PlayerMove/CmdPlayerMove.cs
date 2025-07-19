/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Command;
using UnityEngine;

namespace BonesOfDragonfall
{
    public class CmdPlayerMove : ICommand
    {
        public readonly Vector2 Direction;
        public readonly float Speed;
        public readonly int PlayerId;

        public CmdPlayerMove(Vector2 direction, float speed, int playerId)
        {
            Direction = direction;
            Speed = speed;
            PlayerId = playerId;
        }
    }
}
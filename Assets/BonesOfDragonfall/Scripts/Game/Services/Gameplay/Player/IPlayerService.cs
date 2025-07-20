/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public interface IPlayerService : IDisposable
    {
        void Move(Vector2 direction, float speed, float airSpeed, float dragMovement, bool playerInGround, int playerId);
        void PlayerRotation(Vector2 direction, float sensitivityX, float sensitivityY, int playerId);
        void Jump(float jumpForce, int playerId);
    }
}
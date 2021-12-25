using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AccselerationMoveRB : MoveTransformRB,IAcceleration
    {



        private readonly float _acceleration;
        public AccselerationMoveRB(Transform transform, float speed,float acceleration) : base(transform, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed -= _acceleration;
        }
        public void RemoveAcceleration()
        {
            Speed += _acceleration;
        }
    }
}

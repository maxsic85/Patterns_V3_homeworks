using UnityEngine;
namespace Asteroids
{
    public class AccelerationMove : MoveTransform,IAcceleration
    {
        private readonly float _acceleration;
        public AccelerationMove(Transform transform, float speed, float acceleration)
        : base(transform, speed)
        {
            _acceleration = acceleration;
        }
        public virtual void AddAcceleration()
        {
           Speed -= _acceleration;
        }
        public virtual void RemoveAcceleration()
        {
            Speed += _acceleration;
        }
    }
}
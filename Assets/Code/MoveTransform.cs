﻿using UnityEngine;
namespace Asteroids
{
    public class MoveTransform : IMove
    {
        internal readonly Transform _transform;
        internal Vector3 _move;
        public float Speed { get; protected set; }
        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }
        public virtual void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }

       
    }
}
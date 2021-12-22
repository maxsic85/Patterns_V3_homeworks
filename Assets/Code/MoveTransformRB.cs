using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class MoveTransformRB : MoveTransform
    {
        public MoveTransformRB(Transform transform, float speed) : base(transform, speed)
        {

        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {

            _move.Set(horizontal * Speed, vertical * Speed, 0.0f);
            var rb = _transform.gameObject.GetOrAddComponent<Rigidbody2D>();
            rb.AddForce(_move * Speed);
        }
    }
}

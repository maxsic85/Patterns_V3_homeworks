using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public class BarrelModel
    {
        public BarrelModel(Transform startPosition, float force, float damage)
        {
            this.startPosition = startPosition;
            Force = force;
            Damage = damage;
        }

        public Transform startPosition { get; set; }
        public float Force { get; set; }
        public float Damage { get; set; }


    }
}

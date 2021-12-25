using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Barrel 
    {
        BarrelModel barrelModel;
        BarrelProvider barrelProvider;
      public Rigidbody2D rigidbody2D { get; set; }

        public Barrel(BarrelModel barrelModel, BarrelProvider barrelProvider)
        {
            this.barrelModel = barrelModel;
            this.barrelProvider = barrelProvider;
      
        }

        public float Speed => throw new System.NotImplementedException();

        public void Move(float horizontal, float vertical, float deltaTime)
        {
           
        }
    }
}

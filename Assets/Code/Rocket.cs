using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Rocket 
    {
        RocketModel barrelModel;
      public  RocketProvider barrelProvider;
      public Rigidbody2D rigidbody2D { get; set; }

        public Rocket(RocketModel barrelModel, RocketProvider barrelProvider)
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

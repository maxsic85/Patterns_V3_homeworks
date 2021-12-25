using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipModel
    {
        public ShipModel(float speed, float accseleration, float hP)
        {
            Speed = speed;
            Accseleration = accseleration;
            HP = hP;
          
        }

        public float Speed { get; set; }
        public float Accseleration { get; set; }
        public float HP { get; set; }
        public GameObject GameShip { get; set; }

    }
}

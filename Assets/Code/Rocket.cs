using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    [Serializable]
    public class Rocket
    {
        RocketModel _barrelModel;
        public RocketProvider _barrelProvider { get; set; }
        public Rigidbody2D rigidbody2D { get; set; }
        public Rocket(RocketModel barrelModel, RocketProvider barrelProvider)
        {
            this._barrelModel = barrelModel;
            this._barrelProvider = barrelProvider;

        }
      
    }
}

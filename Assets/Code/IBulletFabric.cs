using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IRocketFabrick 
    {
        public Rocket CreateBarrel(RocketModel  barrelModel);
              
    }
}

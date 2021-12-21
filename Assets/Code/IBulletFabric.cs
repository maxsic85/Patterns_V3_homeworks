using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IBulletFabrick 
    {
        public Barrel CreateBarrel(BarrelModel  barrelModel);
              
    }
}

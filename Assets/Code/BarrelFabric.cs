using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class BarrelFabric : IBulletFabrick
    {
        public Barrel CreateBarrel(BarrelModel barrelModel)
        {
            GameObject Rocket = GameObject.Instantiate(Resources.Load("Rocket", typeof(GameObject))) as GameObject;
            var shipEnemy = new Barrel(barrelModel, Rocket.GetComponent<BarrelProvider>());
            Rocket.transform.position = barrelModel.startPosition.position;
            Rocket.transform.rotation = barrelModel.startPosition.rotation;
            shipEnemy.rigidbody2D = Rocket.GetComponent<Rigidbody2D>();
            return shipEnemy;
        }

      
    }
}

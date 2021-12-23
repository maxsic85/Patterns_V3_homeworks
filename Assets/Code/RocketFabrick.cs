using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class RocketFabrick : IRocketFabrick
    {
        public Rocket CreateBarrel(RocketModel barrelModel)
        {
            GameObject Rocket = GameObject.Instantiate(Resources.Load("Rocket", typeof(GameObject))) as GameObject;
            Rocket.transform.position = barrelModel.startPosition.position;
            Rocket.transform.rotation = barrelModel.startPosition.rotation;
            var shipEnemy = new Rocket(barrelModel, Rocket.GetComponent<RocketProvider>());
            shipEnemy.rigidbody2D = Rocket.GetComponent<Rigidbody2D>();
            return shipEnemy;
        }     
    }
}

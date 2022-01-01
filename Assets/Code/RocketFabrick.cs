using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class RocketFabrick : IRocketFabrick
    {
        public Rocket CreateBarrel(RocketModel barrelModel)
        {
            GameObject InstantiateRocket = GameObject.Instantiate(Resources.Load("Rocket", typeof(GameObject))) as GameObject;
            var shipEnemy = new Rocket(barrelModel, InstantiateRocket.GetComponent<RocketProvider>());
       //   var COPY = shipEnemy.DeepCopy<Rocket>();
        //    Debug.Log(COPY);
            shipEnemy._barrelProvider.transform.position = barrelModel.startPosition.position;
            shipEnemy._barrelProvider.transform.rotation = barrelModel.startPosition.rotation;
            shipEnemy.rigidbody2D = InstantiateRocket.GetComponent<Rigidbody2D>();
            return shipEnemy;
        }     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Starter : MonoBehaviour
    {
        Controllers controllers;

        void Start()
        {
            controllers = new Controllers();
            new GameInitialisation(controllers);
            controllers.Initialisation();

        }

        void Update()
        {
            var deltaTime = Time.deltaTime;
            controllers.Execute(deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Starter : MonoBehaviour
    {
        Controllers controllers;
        TimerSystem tm;
        void Start()
        {
            controllers = new Controllers();
            new GameInitialisation(controllers);
            controllers.Initialisation();
            InvokeRepeating("Invoker", 2f, 2f);
            tm = new TimerSystem(50, 100);
            tm.StartTimerWithOutDispose(this);

        }

        void Update()
        {
            var deltaTime = Time.deltaTime;
            controllers.Execute(deltaTime);

            if (tm.IsElapsed)
            {
                Debug.Log("sdf");
                return;
            }
        }

        private void FixedUpdate()
        {
             
        }

        public void Invoker()
        {
            controllers.Invoker();
        }
    }
}

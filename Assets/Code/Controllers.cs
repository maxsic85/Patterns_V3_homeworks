using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Controllers : IInitialisation, IExecute
    {
        private readonly List<IInitialisation> initialisations;
        private readonly List<IExecute> executes;

        public Controllers()
        {
            initialisations = new List<IInitialisation>();
            executes = new List<IExecute>();
        }

        public Controllers Add(IController controller)
        {
            if (controller is IInitialisation initialisation)
            {
                initialisations.Add(initialisation);
            }
            if (controller is IExecute execute)
            {
                executes.Add(execute);
            }
            return this;
        }

        public void Execute(float deltaTime)
        {
            for (var index = 0; index < executes.Count; ++index)
            {
                executes[index].Execute(deltaTime);
            }
        }

        public void Initialisation()
        {
            for (var i = 0; i < initialisations.Count; ++i)
            {
                initialisations[i].Initialisation();
            }
        }
    }
}

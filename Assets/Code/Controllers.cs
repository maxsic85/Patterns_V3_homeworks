using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Controllers : IInitialisation, IExecute,IInvoke
    {
        private readonly List<IInitialisation> initialisations;
        private readonly List<IExecute> executes;
        private readonly List<IInvoke> invokers;

        public Controllers()
        {
            initialisations = new List<IInitialisation>();
            executes = new List<IExecute>();
            invokers = new List<IInvoke>();
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
            if (controller is IInvoke invoke)
            {
                invokers.Add(invoke);
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

        public void Invoker()
        {
            for (var index = 0; index < invokers.Count; ++index)
            {
                invokers[index].Invoker();
            }
        }
    }
}

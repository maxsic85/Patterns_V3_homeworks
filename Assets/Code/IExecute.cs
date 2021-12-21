using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IExecute : IController
    {
        void Execute(float deltatime);
    }
}

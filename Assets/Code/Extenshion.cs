using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static class Extenshion
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.GetComponent<T>() == null) gameObject.AddComponent<T>();
            return gameObject.GetComponent<T>();

        }
    }
}

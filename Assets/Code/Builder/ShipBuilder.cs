using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSuhinin.Builder
{
    public class ShipBuilder
    {
        protected GameObject _gameObject;
        public ShipBuilder() => _gameObject = new GameObject();
        protected ShipBuilder(GameObject gameObject) => _gameObject = gameObject;

        public ShipBulderRigidBody shipBulderRigidBody => new ShipBulderRigidBody(_gameObject);

        public ShipBulderSound shipBulderSound => new ShipBulderSound(_gameObject);

        internal T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (result == null) _gameObject.AddComponent<T>();
            return result;
        }

        public static implicit operator GameObject(ShipBuilder shipBuilder)
        {
            return shipBuilder._gameObject;
        }
    }
}

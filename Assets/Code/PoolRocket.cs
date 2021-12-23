
using Pool;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class PoolRocket
    {
        IRocketFabrick _rocketFabrick;
        RocketModel _rocketModel;
        private readonly int _capacityPool;
        private Transform _rootPool;
        private readonly Dictionary<string, HashSet<RocketProvider>> _rocketPool;
        public PoolRocket(int capacity,IRocketFabrick rocketFabrick, RocketModel rocketModel)
        {
            _rocketModel = rocketModel;
            _rocketFabrick = rocketFabrick;
            _rocketPool = new Dictionary<string, HashSet<RocketProvider>>();
            _capacityPool = capacity;
            if (_rootPool == null)
            {
         
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }
        public RocketProvider GetBuilett(string type)
        {
            RocketProvider result = type switch
            {
                "rocket" => GetRocket(GetListRockets(type)),
                "" => null
            };
            return result;

        }
        public RocketProvider GetRocket(HashSet<RocketProvider> rockets)
        {
            var rocket = rockets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (rocket == null)
            {

                for (var i = 0; i < _capacityPool; i++)
                {

                    var instantiate = _rocketFabrick.CreateBarrel(_rocketModel).barrelProvider;
                    ReturnToPool(instantiate.transform);
                    rockets.Add(instantiate);
                }
                GetRocket(rockets);
            }
            rocket = rockets.FirstOrDefault(a => !a.gameObject.activeSelf);
            rocket.gameObject.transform.position = _rocketModel.startPosition.position;
            rocket.gameObject.transform.rotation = _rocketModel.startPosition.rotation;
            return rocket;
        }
        private HashSet<RocketProvider> GetListRockets(string type)
        {
            return _rocketPool.ContainsKey(type) ? _rocketPool[type] :
            _rocketPool[type] = new HashSet<RocketProvider>();
        }
        private void ReturnToPool(Transform transform)
        {
           // transform.localPosition = Vector3.zero;
           // transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }
        public void RemovePool()
        {
            UnityEngine.Object.Destroy(_rootPool.gameObject);
        }

    }
}

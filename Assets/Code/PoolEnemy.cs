using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using System.Linq;

namespace Asteroids
{
    public class PoolEnemy
    {
        private readonly int _capacityPool;
        ShipInitialisation _shipInitialisation;
        ShipModel _enemyModel;
        private Transform _rootPool;
        private readonly float offset = 2; 
        private Vector2 StartPosition
        {
            get
            {
              //  var random = Random.Range(-8, 8);
                var random = Random.Range(Camera.main.transform.localPosition.z + offset, -1*Camera.main.transform.localPosition.z-offset);

                var vector = new Vector2(random, 5);
                return vector;
            }
         
        }

        private readonly Dictionary<string, HashSet<EnemyProvider>> _enemyPool;

        public PoolEnemy(int capacity, ShipInitialisation shipInitialisation)
        {
            _enemyModel = shipInitialisation._shipModel;
            _capacityPool = capacity;
            _shipInitialisation = shipInitialisation;
            _enemyPool = new Dictionary<string, HashSet<EnemyProvider>>();
            if (_rootPool==null)
            {
                _rootPool = new GameObject(NameManager.POOL_ENEMY).transform;
            }
        }
        public EnemyProvider GetEnemy(string type)
        {
            EnemyProvider result = type switch
            {
                "asteroid" => GetAsteroid(GetListEnemies(type)),
                "enemyship" => GetEnemyShip(GetListEnemies(type)),
                "" => null
            };
            return result;
        }
        private EnemyProvider GetAsteroid(HashSet<EnemyProvider> asteroids)
        {
            _enemyModel.TypeShip = ShipType.ASTEROID;
            var enemy = asteroids.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
              
                for (var i = 0; i < _capacityPool; i++)
                {

                    var instantiate = _shipInitialisation._shipFabric.CreateEnemyShip(_enemyModel).CurrentEnemy;
                    ReturnToPool(instantiate.transform);
                    asteroids.Add(instantiate);
                }
                GetAsteroid(asteroids);
            }
            enemy = asteroids.FirstOrDefault(a => !a.gameObject.activeSelf);
            enemy.SetStartPosition(StartPosition);
            return enemy;
        }
        private EnemyProvider GetEnemyShip(HashSet<EnemyProvider> ships)
        {
            _enemyModel.TypeShip = ShipType.ENEMY;
            var rocket = ships.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (rocket == null)
            {

                for (var i = 0; i < _capacityPool; i++)
                {

                    var instantiate = _shipInitialisation._shipFabric.CreateEnemyShip(_enemyModel).CurrentEnemy;
                    ReturnToPool(instantiate.transform);
                    ships.Add(instantiate);
                }
                GetAsteroid(ships);
            }
            rocket = ships.FirstOrDefault(a => !a.gameObject.activeSelf);
            rocket.SetStartPosition(StartPosition);
            return rocket;
        }
        private HashSet<EnemyProvider> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] :
            _enemyPool[type] = new HashSet<EnemyProvider>();
        }
        private void ReturnToPool(Transform transform)
        {
            // transform.localPosition = Vector3.zero;
            // transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }
    }
}

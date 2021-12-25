using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyController : IInvoke, IExecute
    {

        EnemyProvider _currentEnemy;
        EnemyProvider _currentAsteroid;
        PoolEnemy _poolEnemy;
        PoolRocket _poolRocket;
        public int GetEnemyNumber
        {
            get
            {
                return Random.Range(0, 3);
            }

        }
        public EnemyController(PoolEnemy poolEnemy, PoolRocket poolRocket)
        {
            _poolEnemy = poolEnemy;
            _poolRocket = poolRocket;
          //  GetAsteroid(_poolEnemy);
         //   GetsHIP(_poolEnemy);
        }

        private void GetEnenmyOnSceene(int number)
        {
            switch (number)
            {
                case 1: GetAsteroid(_poolEnemy); _currentAsteroid.OnActive(); break;
                case 2: GetsHIP(_poolEnemy); _currentEnemy.OnActive(); break;
                default:
                    GetAsteroid(_poolEnemy);
                    break;
            }
        }
        private void GetAsteroid(PoolEnemy poolEnemy)
        {
            _currentAsteroid = poolEnemy.GetEnemy("asteroid");

        }

        private void GetsHIP(PoolEnemy poolEnemy)
        {
            _currentEnemy = poolEnemy.GetEnemy("enemyship");
            EnemyShoot();
        }
        void EnemyShoot()
        {
            var rocket = _poolRocket.GetBuilett("rocket");
            rocket.UpdatePosition(_currentEnemy.transform);
            rocket.OnActive();
            rocket.rigidbody2D.AddForce(Vector3.down * _poolRocket._rocketModel.Force * 3);
        }


        public void Execute(float deltatime)
        {

        }

        public void Invoker()
        {
            GetEnenmyOnSceene(GetEnemyNumber);
        }
    }
}

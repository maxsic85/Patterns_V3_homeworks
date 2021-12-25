using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class PoolStarter : MonoBehaviour
    {
        EnemyPool enemyPool;
        Enemy Enemy;
        void Start()
        {
            enemyPool = new EnemyPool(5);
            Enemy = new Enemy();

        }
        private void GetNewEnemy(EnemyPool enemyPool)
        {
            var enemy = enemyPool.GetEnemy("Asteroid");
            var enemy2 = enemyPool.GetEnemy("enemy");
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetNewEnemy(enemyPool);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
               enemyPool.GetEnemy("Asteroid").ActiveEnemy(Vector3.one,Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                enemyPool.GetEnemy("enemy").ActiveEnemy(Vector3.one, Quaternion.identity);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Enemy.CreateAsteroidEnemy();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameInitialisation
    {

        public GameInitialisation(Controllers controllers)
        {
            var shipPlayerModel = new ShipModel(30, 40, 500,ShipType.PLAYER);
            var shipFabric = new ShipFabric();
            var player = new ShipInitialisation(shipFabric, shipPlayerModel, ShipType.PLAYER);
            var shiEnemyModel = new ShipModel(30, 40, 500, ShipType.ENEMY);
            player.CreateShip(shipFabric, shiEnemyModel, ShipType.PLAYER);
            var enemyInitialisation = new ShipInitialisation(shipFabric, shiEnemyModel, ShipType.ENEMY);
            var poolEnemy = new PoolEnemy(5, enemyInitialisation);
            ServiceLocator.SetService<PoolEnemy>(poolEnemy);
            var moveController = new MoveController(player, Camera.main);
            var rocketModel = new RocketModel(player.CurrentShip._shipView.transform, 100, 10);
            var poolRocket = new PoolRocket(10, new RocketFabrick(), rocketModel);
            var playerShootController = new ShootController(poolRocket, player);
            var enemyController = new EnemyController(ServiceLocator.Resolve<PoolEnemy>(),poolRocket);
         

            controllers.Add(player);
            controllers.Add(enemyInitialisation);
            controllers.Add(moveController);
            controllers.Add(playerShootController);
            controllers.Add(enemyController);
         

        }

    }
}

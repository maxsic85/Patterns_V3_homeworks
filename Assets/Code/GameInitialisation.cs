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
            var enemyController = new EnemyController(poolEnemy);
            var moveController = new MoveController(player, Camera.main);
            var rocketModel = new RocketModel(player.CurrentShip._shipView.transform, 100, 10);
            var playerShootController = new ShootController(new PoolRocket(10, new RocketFabrick(), rocketModel), player);

            controllers.Add(player);
            controllers.Add(enemyInitialisation);
            controllers.Add(moveController);
            controllers.Add(playerShootController);
            controllers.Add(enemyController);

        }

    }
}

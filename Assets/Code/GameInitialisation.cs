using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameInitialisation
    {
       
        public GameInitialisation(Controllers controllers)
        {
            var shipModel = new ShipModel(30, 40, 500);
            var shipFabric = new ShipFabric();
            var player = new ShipInitialisation(shipFabric, shipModel, ShipType.PLAYER);
            var enemy = new ShipInitialisation(shipFabric, shipModel, ShipType.ENEMY);
            var moveController = new MoveController(player,Camera.main);
            var rocketModel = new RocketModel(player.CurrentShip._shipView.transform, 100, 10);
            var playerShootController = new ShootController(rocketModel,new PoolRocket(10, new RocketFabrick(), rocketModel),player);

            controllers.Add(player);
            controllers.Add(enemy);
            controllers.Add(moveController);
            controllers.Add(playerShootController);
        }

    }
}

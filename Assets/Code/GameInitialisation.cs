using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameInitialisation
    {
        public GameInitialisation(Controllers controllers)
        {
            var shipModel = new ShipModel(50, 40, 500);
            var shipFabric = new ShipFabric();
            var player = new ShipInitialisation(shipFabric, shipModel, ShipType.PLAYER);
            var enemy = new ShipInitialisation(shipFabric, shipModel, ShipType.ENEMY);
            var moveController = new MoveController(player,Camera.main);
            var playerShootController = new ShootController(new BarrelModel(player.CurrentShip._shipView.transform,100,10),new BarrelFabric(),player);

            controllers.Add(player);
            controllers.Add(enemy);
            controllers.Add(moveController);
            controllers.Add(playerShootController);
        }

    }
}

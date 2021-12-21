using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipFabric : IShipFabric
    {

        public Ship CreateEnemy(ShipModel shipModel)
        {
            GameObject enemy = GameObject.Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;
            var move = new MoveTransform(enemy.transform, shipModel.Speed);
            var rotation = new RotationShip(enemy.transform);
            shipModel.GameShip = enemy;
            var shipEnemy = new Ship(shipModel, enemy.GetComponent<ShipView>(), move, rotation);
            return shipEnemy;
        }

        public Ship CreatePlayer(ShipModel shipModel)
        {
            GameObject player = GameObject.Instantiate(Resources.Load("player", typeof(GameObject))) as GameObject;
            var move = new AccelerationMove(player.transform, shipModel.Speed,shipModel.Accseleration);
            var rotation = new RotationShip(player.transform);
            shipModel.GameShip = player;
            var shipPlayer = new Ship(shipModel, player.GetComponent<ShipView>(), move, rotation);
            player.GetComponent<PlayerProvider>()._ship = shipPlayer;
            return shipPlayer;
        }
    }
}

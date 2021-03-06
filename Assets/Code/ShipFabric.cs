using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipFabric : IShipFabric
    {
        IMove GetMove;
        public Ship CreateEnemyShip(ShipModel shipModel)
        {
            GameObject enemy = shipModel.TypeShip switch
            {
                ShipType.ASTEROID => GameObject.Instantiate(Resources.Load(shipModel.TypeShip.ToString(), typeof(GameObject))) as GameObject,
                ShipType.ENEMY => GameObject.Instantiate(Resources.Load(shipModel.TypeShip.ToString(), typeof(GameObject))) as GameObject,
                ShipType.ENEMY2 => GameObject.Instantiate(Resources.Load(shipModel.TypeShip.ToString(), typeof(GameObject))) as GameObject,

            };

            GetMove = new MoveTransform(enemy.transform, shipModel.Speed);
            var rotation = new RotationShip(enemy.transform);
            shipModel.GameShip = enemy;
            var shipEnemy = new Ship(shipModel, enemy.GetComponent<ShipView>(), GetMove, rotation);
            shipEnemy.CurrentEnemy = enemy.GetComponent<EnemyProvider>();
            return shipEnemy;
        }
        public Ship CreatePlayerWithOutRigitBody(ShipModel shipModel)
        {
            GameObject player = GameObject.Instantiate(Resources.Load("player", typeof(GameObject))) as GameObject;
            GetMove = new AccelerationMove(player.transform, shipModel.Speed, shipModel.Accseleration);
            var rotation = new RotationShip(player.transform);
            shipModel.GameShip = player;
            var shipPlayer = new Ship(shipModel, player.GetComponent<ShipView>(), GetMove, rotation);
            player.GetComponent<PlayerProvider>()._ship = shipPlayer;
            return shipPlayer;
        }
        public Ship CreatePlayerWithRigitBody(ShipModel shipModel)
        {
            GameObject player = GameObject.Instantiate(Resources.Load("player", typeof(GameObject))) as GameObject;
            GetMove = new AccselerationMoveRB(player.transform, shipModel.Speed, shipModel.Accseleration);
            var rotation = new RotationShip(player.transform);
            shipModel.GameShip = player;
            var shipPlayer = new Ship(shipModel, player.GetComponent<ShipView>(), GetMove, rotation);
            player.GetComponent<PlayerProvider>()._ship = shipPlayer;
            return shipPlayer;
        }
    }
}

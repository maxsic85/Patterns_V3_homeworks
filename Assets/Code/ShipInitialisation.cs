using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipInitialisation : IInitialisation
    {

        IShipFabric shipFabric;
        public Ship CurrentShip { get;  }

        public ShipInitialisation(IShipFabric shipFabric, ShipModel shipModel, ShipType shipType)
        {
            this.shipFabric = shipFabric;

            Ship ship = shipType switch
            {
                ShipType.PLAYER => shipFabric.CreatePlayer(shipModel),
                ShipType.ENEMY => shipFabric.CreateEnemy(shipModel),
                0 => null
            };
            CurrentShip = ship;

        }

        public void Initialisation()
        {
           
        }
    }
}

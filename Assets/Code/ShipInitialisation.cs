using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipInitialisation : IInitialisation
    {

        IShipFabric _shipFabric;
        public Ship CurrentShip { get;  }

        public ShipInitialisation(IShipFabric shipFabric, ShipModel shipModel, ShipType shipType)
        {
            _shipFabric = shipFabric;

            Ship ship = shipType switch
            {
                ShipType.PLAYER => _shipFabric.CreatePlayerWithRB(shipModel),
                ShipType.ENEMY => _shipFabric.CreateEnemy(shipModel),
                0 => null
            };
            CurrentShip = ship;

        }

        public void Initialisation()
        {
           
        }
    }
}

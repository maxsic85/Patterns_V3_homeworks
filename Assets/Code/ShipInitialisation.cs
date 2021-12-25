using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShipInitialisation : IInitialisation
    {

        internal IShipFabric _shipFabric;
        internal ShipModel _shipModel;
        internal ShipType _shipType;
        public Ship CurrentShip { get; set; }

        public ShipInitialisation CreateShip(IShipFabric shipFabric, ShipModel shipModel, ShipType shipType)
        {
            _shipFabric = shipFabric;
            _shipModel = shipModel;
            _shipType = shipType;
            Ship ship = shipType switch
            {
                ShipType.PLAYER => _shipFabric.CreatePlayerWithRigitBody(shipModel),
                ShipType.ENEMY => _shipFabric.CreateEnemyShip(shipModel),
                0 => null
            };
            CurrentShip = ship;
            return this;
        }

        //FOR USE POOL
        public ShipInitialisation(IShipFabric shipFabric, ShipModel shipModel, ShipType shipType)
        {
            _shipFabric = shipFabric;
            _shipModel = shipModel;
            _shipType = shipType;
         
        }

        public void Initialisation()
        {

        }
    }
}

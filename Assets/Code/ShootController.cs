using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShootController : IExecute
    {
        Ship shootingShip;
        RocketModel barrelModel;
        PoolRocket _poolRocket ;
        RocketProvider _currentRocket;
        [SerializeField] private Transform _startPosition;

        public ShootController(PoolRocket poolRocket ,ShipInitialisation ship)
        {
            this.barrelModel = poolRocket._rocketModel;
            _startPosition = poolRocket._rocketModel.startPosition;
            shootingShip = ship.CurrentShip;
            _poolRocket = poolRocket;
            _currentRocket= _poolRocket.GetBuilett("rocket");
        }

        public void Execute(float deltatime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _startPosition = shootingShip._shipView.transform;
                _currentRocket= _poolRocket.GetBuilett("rocket");
                _currentRocket.OnActive();
                _currentRocket.rigidbody2D.AddForce(_startPosition.up * barrelModel.Force);
            }
        }
    }
}

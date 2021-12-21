using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ShootController : IExecute
    {
        Ship shootingShip;
        BarrelModel barrelModel;
        IBulletFabrick  currentBurrel;
        //[SerializeField] private Rigidbody2D _rocket;
        [SerializeField] private Transform _startPosition;

        public ShootController(BarrelModel barrelModel,IBulletFabrick bulletFabrick,ShipInitialisation ship)
        {
            this.barrelModel = barrelModel;
            _startPosition = barrelModel.startPosition;
            shootingShip = ship.CurrentShip;
            currentBurrel = bulletFabrick;
        }

        public void Execute(float deltatime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _startPosition = shootingShip._shipView.transform;
                var rocket = currentBurrel.CreateBarrel(barrelModel);
                //  rocket.Move(100,1,Time.deltaTime);
                //var temAmmunition = Instantiate(_rocket, barrelModel.startPosition.position,
                //_startPosition.rotation);
                rocket.rigidbody2D.AddForce(_startPosition.up * barrelModel.Force);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Starter : MonoBehaviour
    {
        Controllers controllers;

        IBulletFabrick bulletFabrick;

        public Ship Ship;
        private Camera _camera;
        BarrelModel barrelModel;
        [SerializeField] private Rigidbody2D _rocket;
        [SerializeField] private Transform _startPosition;
 
        void Start()
        {
            controllers = new Controllers();
            new GameInitialisation(controllers);
            controllers.Initialisation();
            _camera = Camera.main;


            bulletFabrick = new BarrelFabric();
            barrelModel = new BarrelModel(_startPosition, 50, 10);

        }


        void Update()
        {
            var deltaTime = Time.deltaTime;
            controllers.Execute(deltaTime);
        }

        private void InputHandler()
        {
     
            if (Input.GetButtonDown("Fire1"))
            {
                _startPosition = Ship._shipView.transform;
                var rocket= bulletFabrick.CreateBarrel(new BarrelModel(_startPosition, 100,100));
                //  rocket.Move(100,1,Time.deltaTime);
                //var temAmmunition = Instantiate(_rocket, barrelModel.startPosition.position,
                //_startPosition.rotation);
                rocket.rigidbody2D.AddForce(_startPosition.up * barrelModel.Force);
            }
        }
    }
}

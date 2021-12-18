using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Starter : MonoBehaviour
    {
        IShipFabric shipFabric;
        IBulletFabrick bulletFabrick;
        ShipModel shipModel;
        public Ship Ship;
        private Camera _camera;
        BarrelModel barrelModel;
        [SerializeField] private Rigidbody2D _rocket;
        [SerializeField] private Transform _startPosition;
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            shipModel = new ShipModel(50, 40, 500);
            shipFabric = new ShipFabric();
            bulletFabrick = new BarrelFabric();
            Ship = shipFabric.CreatePlayer(shipModel);
         //   _startPosition = Ship._shipView.transform;
            barrelModel = new BarrelModel(_startPosition, 50, 10);
            shipFabric.CreateEnemy(shipModel);
        }

        // Update is called once per frame
        void Update()
        {
            InputHandler();
            Ship._shipView.UpdateUI(Ship);

          
        }

        private void InputHandler()
        {
            Ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
              Time.deltaTime);

            var direction = Input.mousePosition -
         _camera.WorldToScreenPoint(transform.position);
            Ship.Rotation(direction);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Ship.RemoveAcceleration();
            }
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

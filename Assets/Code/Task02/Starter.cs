using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Starter : MonoBehaviour
    {
        IShipFabric shipFabric;
        ShipModel shipModel;
        public Ship Ship;
        private Camera _camera;
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            shipModel = new ShipModel(50, 40, 500);
            shipFabric = new ShipFabric();
            Ship = shipFabric.CreatePlayer(shipModel);

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
        }
    }
}

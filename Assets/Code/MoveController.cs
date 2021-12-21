using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class MoveController : IExecute
    {
        ShipInitialisation ship;
        Camera camera;

        public MoveController(ShipInitialisation ship, Camera camera)
        {
            this.ship = ship;
            this.camera = camera;
        }

        //IInput input

        public void Execute(float deltatime)
        {
            ship.CurrentShip.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
             Time.deltaTime);

            var direction = Input.mousePosition -
       camera.WorldToScreenPoint(ship.CurrentShip._shipView.transform.position);

            ship.CurrentShip.Rotation(direction);


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ship.CurrentShip.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ship.CurrentShip.RemoveAcceleration();
            }
        }
    }
}

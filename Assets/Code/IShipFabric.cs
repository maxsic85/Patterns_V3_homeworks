using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IShipFabric
    {
        Ship CreatePlayerWithOutRigitBody(ShipModel shipModel);
        Ship CreatePlayerWithRigitBody(ShipModel shipModel);
        Ship CreateEnemyShip(ShipModel shipModel);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IShipFabric
    {
        Ship CreatePlayer(ShipModel shipModel);
        Ship CreateEnemy(ShipModel shipModel);
    }
}

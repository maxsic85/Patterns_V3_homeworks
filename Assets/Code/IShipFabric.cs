using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IShipFabric
    {
        Ship CreatePlayerWithOutRB(ShipModel shipModel);
        Ship CreatePlayerWithRB(ShipModel shipModel);
        Ship CreateEnemy(ShipModel shipModel);
    }
}

using UnityEngine;

namespace MSuhinin.Builder
{
    public class ShipBulderRigidBody : ShipBuilder
    {
        public ShipBulderRigidBody(GameObject gameObject) : base(gameObject)
        {

        }

        public ShipBulderRigidBody RBody()
        {
            GetOrAddComponent<Rigidbody2D>();
            return this;
        }
    }
}
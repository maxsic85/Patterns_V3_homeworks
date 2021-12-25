using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerProvider : MonoBehaviour
    {
        public Ship _ship {get;set;}

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_ship.hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _ship.hp--;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_ship.hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _ship.hp--;
            }
        }

        private void OnBecameInvisible()
        {
            transform.position = Vector3.down;
        }
    }
}

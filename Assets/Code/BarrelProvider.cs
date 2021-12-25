using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BarrelProvider : MonoBehaviour
    {
        public Rigidbody2D rigidbody2D { get; set; }
        // Start is called before the first frame update
        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
}

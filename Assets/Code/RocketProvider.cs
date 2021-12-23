using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RocketProvider : MonoBehaviour
    {

        public Rigidbody2D rigidbody2D { get; set; }

        private Transform root;
        public Transform Root
        {
            get
            {
                root = GameObject.Find(NameManager.POOL_AMMUNITION).transform;
                root = (root == null) ? GameObject.Instantiate(new GameObject(), Vector3.zero, Quaternion.identity).transform : root;
                return root;
            }
            set => root = value;
        }
        public void RetunrToPool()
        {
            this.gameObject.transform.SetParent(Root);
            rigidbody2D.AddForce(Vector2.zero);
            this.gameObject.SetActive(false);
        }
        public void OnActive()
        {
            gameObject.SetActive(true);
        }



        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
           // RetunrToPool();
        }

        private void OnBecameInvisible()
        {
            RetunrToPool();
        }


    }
}

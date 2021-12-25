using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyProvider : MonoBehaviour
    {
        private Transform root;
        public Rigidbody2D _rigitbody { get; set; }
        public Transform Root
        {
            get
            {
                root = GameObject.Find(NameManager.POOL_ENEMY).transform;
                root = (root == null) ? GameObject.Instantiate(new GameObject(), Vector3.zero, Quaternion.identity).transform : root;
                return root;
            }
            set => root = value;
        }
        void Awake()
        {
            _rigitbody = GetComponent<Rigidbody2D>();
        }
        public void RetunrToPool()
        {
            this.gameObject.transform.SetParent(Root);
            this.gameObject.transform.localPosition = Vector2.one;
            _rigitbody.velocity = Vector2.zero;
            this.gameObject.SetActive(false);

          
        }
        public void OnActive()
        {
            gameObject.SetActive(true);
            _rigitbody.AddForce(Vector2.down * 100);

        }
        public void SetStartPosition(Vector2 pos)
        {
            transform.position = pos;
          
        }
        private void OnBecameInvisible()
        {
            RetunrToPool();
        }
    }
}

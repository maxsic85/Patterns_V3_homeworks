using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        private Transform _rotPool;
        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }
        public static Enemy CreateAsteroidEnemy()
        {
            var enemy = Instantiate(Resources.Load<Enemy>("Aster"));
          
            return enemy;
        }
        public static Enemy CreateShipEnemy()
        {
            var enemy = Instantiate(Resources.Load<Enemy>("ene"));

            return enemy;
        }
        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }
        private void OnBecameInvisible()
        {
            ReturnToPool();
        }
    }

   
}

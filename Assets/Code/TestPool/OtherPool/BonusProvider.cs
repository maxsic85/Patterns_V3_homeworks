using UnityEngine;

namespace Pool
{
    public class BonusProvider:MonoBehaviour
    {
        public int Speed;
        public Bonus CurrentBonus { get; set; }

        private Transform root;
        public Transform Root
        {
            get
            {
                root = GameObject.Find("ROOOT").transform;
                root = (root == null) ? GameObject.Instantiate(new GameObject(), Vector3.zero, Quaternion.identity).transform : root;
                return root;
            }
            set => root = value;
        }
        public void RetunrToPool()
        {
            gameObject.transform.SetParent(Root);
            gameObject.SetActive(false);
        }
        public void OnActive()
        {
            gameObject.SetActive(true);
        }

        public void Init(BonusData bonus)
        {
            Speed = bonus.Speed;
        
          
        }
        private void Start()
        {
            RetunrToPool();
        }
    }
}
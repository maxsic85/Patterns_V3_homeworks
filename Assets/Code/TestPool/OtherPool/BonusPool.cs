using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pool
{
    public class BonusPool
    {
        public Dictionary<string, List<BonusProvider>> bonusPool;
        public int Capacity = 5;
        private Transform root;

        public BonusPool(int cap)
        {
            bonusPool = new Dictionary<string, List<BonusProvider>>();
            Capacity = cap;

            if (root == null)
            {
                root = new GameObject("ROOOT").transform;
            }
        }

        public BonusProvider GetBonus(string type, BonusData bonusData) => GetBonus(GetBonusList(type), bonusData);

        private List<BonusProvider> GetBonusList(string type)
        {
            return bonusPool.ContainsKey(type) ? bonusPool[type] :
          bonusPool[type] = new List<BonusProvider>();

        }

        private BonusProvider GetBonus(List<BonusProvider> bonuses, BonusData bonusData)
        {
            BonusProvider bonusProvider;
            var bonus = bonuses.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bonus == null)
            {
                for (int i = 0; i < Capacity; i++)
                {
                    var inst = Bonus.CreatePositiveBonus(bonusData, out bonusProvider);

                    bonuses.Add(bonusProvider);
                    ReturnToPool(bonusProvider.transform);
                }
                GetBonus(bonuses, bonusData);
            }
            bonus = bonuses.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bonus;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(root);
        }

    }
}

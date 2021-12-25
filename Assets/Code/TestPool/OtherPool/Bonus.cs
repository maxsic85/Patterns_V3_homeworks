using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class Bonus
    {
      static  BonusData bonusData;
        public static Bonus CreatePositiveBonus(BonusData data, out BonusProvider bonusProvider)
        {
            var bonus = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bonusData = data;
            bonusProvider = bonus.AddComponent<BonusProvider>();

            bonusProvider.Init(data);
            return bonusProvider.CurrentBonus;

        }
    }

    public class BonusData
    {
        public BonusData(int speed)
        {
            Speed = speed;
        }

        public int Speed { get ; set ; }
    }
}

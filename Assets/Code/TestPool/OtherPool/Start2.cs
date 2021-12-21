using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class Start2 : MonoBehaviour
    {

        BonusPool bonusPool;
        BonusData bonusData;
        // Start is called before the first frame update
        void Start()
        {
            bonusPool = new BonusPool(2);
            bonusData = new BonusData(2);
            bonusPool.GetBonus("Good",bonusData);



        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bonusPool.GetBonus("Good", bonusData).OnActive();
            }
        }
    }
}

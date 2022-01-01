using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class TestStart1 : MonoBehaviour
    {
        [SerializeField] int setTimer=5;
        ITimer testTimer2;
     
        void Start()
        {
        
            testTimer2 = new TestTimer(setTimer, TimerPeriod._10MS,true);
            testTimer2.Elapsed += ActionTimer;
        }

        private void ActionTimer()
        {
            Debug.Log($"endTimer");
        }

        // Update is called once per frame
        void Update()
        {
      
            if (Input.GetKeyDown(KeyCode.Y))
            {
                testTimer2.StartTimer(this,TimerType.AUTOREST);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                testTimer2.StopTimer();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                testTimer2.ChangeTimer(setTimer);
            }
        }
    }
}

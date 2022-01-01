using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class TestStart : MonoBehaviour
    {
        ITimer testTimer;
    
        void Start()
        {
            testTimer = new TestTimer(5);
            testTimer.Elapsed += ActionTimer;
        }

        private void ActionTimer()
        {
            Debug.Log($"endTimertretertertertertertert");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                testTimer.StartTimer(this,TimerType.AUTOREST);
            }      
        }
    }
}

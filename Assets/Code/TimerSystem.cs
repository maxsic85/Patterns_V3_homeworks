using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Asteroids
{
    public class TimerSystem
    {
        public delegate void ElapsedtTimer();
        public event ElapsedtTimer Elapsed;
        
        private int timer = 0;
        public bool IsElapsed { get; private set; }
        public int Timer { get => timer; private set => timer = value; }

        Timer _timer;
        int _timerValue, _period;
        public TimerSystem(int timerValue, int period)
        {
            this._timerValue = timerValue;
            this._period = period;
        }

        public TimerSystem(int timerValue)
        {
            this._timerValue = timerValue;

        }

        public void StartTimerWithOutDispose(object o)
        {
            TimerCallback tm = new TimerCallback(WaitWithOutDispose);
            _timer = new System.Threading.Timer(tm, 0, 0, _period);
        }
        //For AI Shooting
        public void WaitWithOutDispose(object o)
        {
            if (timer >= _timerValue)
            {

                IsElapsed = true;
                timer = 0;
                Debug.Log(_timerValue);
              
                Elapsed();
                return;
            }
            else
            {
                //  Elapsed(o.ToString());
                IsElapsed = false;
                timer += 1;
            }
        }
        //public void StartTimerWithDispose(object o)
        //{
        //    TimerCallback tm = new TimerCallback(WaitWithDispose);
        //    _timer = new Timer(tm, 0, 0, _period);
        //}
        ////Delay For Player Shooting
        //public void WaitWithDispose(object o)
        //{
        //    if (timer >= _timerValue)
        //    {
        //        IsElapsed = true;
        //        _timer.Dispose();
        //        Elapsed(o.ToString());
        //        Timer = 0;
        //        return;
        //    }
        //    else
        //    {
        //        timer += 1;
        //        IsElapsed = false;
        //    }
        //}
    }

}


using System;
using System.Threading;
namespace Asteroids
{
    public interface ITimer
    {
        bool IsElapsed { get; }
        bool IsStarted { get; }

        event Action Elapsed;
        void StartTimer(object o, TimerType timerType);
        void StopTimer();
        void ChangeTimer(int timerValue);
    }
}

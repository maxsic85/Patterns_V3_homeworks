using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Asteroids
{
    public class TestTimer : ITimer, IDisposable
    {

        public event Action Elapsed;
        private float _timeValuer = 0;
        Timer _timer;
        int _timerTask, _timerPeriod;
        TimerPeriod _currentTimePeriod;
        bool _taskInMS = false;

        private bool _isElapsed, _isStarted;
        public bool IsElapsed { get => _isElapsed; }
        public bool IsStarted { get => _isElapsed; }
        public float Timer { get => _timeValuer; private set => _timeValuer = value; }

        /// <summary>
        /// ����������� �� ������ ������� � ������ ������ 1 �������
        /// </summary>
        /// <param name="timerTask"></param>
        public TestTimer(int timerTask)
        {
            this._timerTask = timerTask;
            this._timerPeriod = 1000; // 1000ms = 1sec
            _currentTimePeriod = TimerPeriod._1SEC;
        }

        /// <summary>
        /// ������ ����� ��������� � ������ ���������� 1 �������, 100 �� ��� 10 ��
        /// ��������� ������� ����� 1 �������
        /// </summary>
        /// <param name="timeTask">������� �� ������ ����������� � ��������</param>
        /// <param name="timerPeriod">enum ����� �����</param>
        public TestTimer(int timeTask, TimerPeriod timerPeriod)
        {
            _timerPeriod = timerPeriod switch
            {
                TimerPeriod._1SEC => _timerPeriod = 1000,
                TimerPeriod._100MS => _timerPeriod = 100,
                TimerPeriod._10MS => _timerPeriod = 10,
            };
            _timerTask = timeTask;
            SetTaskToSeconds(timerPeriod, timeTask, out _timerTask);
            _currentTimePeriod = timerPeriod;
        }

        /// <summary>
        /// ������ ����� ��������� � ������ ���������� 1 �������, 100 �� ��� 10 ��
        /// ��������� ������� ����������� � ������������
        /// ���� ������ 100�� =�� ������� �������� �� 10 , �� ���� ������� 100=10��������
        /// ���� ������ 10�� =�� ������� �������� �� 100 , �� ���� ������� 100=1�������
        /// </summary>
        /// <param name="timeTask"></param>
        /// <param name="timerPeriod">���� ������� </param>
        /// <param name="taskInMS"></param>
        public TestTimer(int timeTask, TimerPeriod timerPeriod, bool taskInMS)
        {
            _taskInMS = taskInMS;
            _timerPeriod = timerPeriod switch
            {
                TimerPeriod._1SEC => _timerPeriod = 1000,
                TimerPeriod._100MS => _timerPeriod = 100,
                TimerPeriod._10MS => _timerPeriod = 10,
            };
            _timerTask = timeTask;
            _currentTimePeriod = timerPeriod;
        }
        private void SetTaskToSeconds(TimerPeriod timerPeriod, int set, out int task)
        {
            task = set;
            task = timerPeriod switch
            {
                TimerPeriod._1SEC => task *= 1,
                TimerPeriod._100MS => task *= 10,
                TimerPeriod._10MS => task *= 100,
            };
        }

        public void StartTimer(object o, TimerType timerType)
        {
            if (_isStarted) return;

            TimerCallback timerCallback = timerType switch   //  TimerCallback �������� �������� ����� ���������� � ���� � ��������� ��������
            {
                TimerType.AUTOREST => new TimerCallback(AutoResetTimer),
                TimerType.RESETWITHKEY => new TimerCallback(OneShotTimer),
            };

            _timer = new Timer(timerCallback, 0, 0, _timerPeriod);
        }

        public void StopTimer()
        {
            Dispose();
        }

        public void ChangeTimer(int timerValue)
        {
            _timerTask = timerValue;
            if (!_taskInMS) SetTaskToSeconds(_currentTimePeriod, timerValue, out _timerTask);
        }

        //for turel fire  for examle 
        public void AutoResetTimer(object o)
        {
            Debug.Log(_timerTask);
            _isStarted = true;
            if (_timeValuer >= _timerTask)
            {
                _isStarted = false;
                _isElapsed = true;
                _timeValuer = 0;
                Elapsed();
                return;
            }
            else
            {
                _isElapsed = false;
                _timeValuer += 1;

            }
        }
        // for click fire 
        public void OneShotTimer(object o)
        {
            _timeValuer += 1;
            _isStarted = true;
            if (_timeValuer >= _timerTask)
            {
                Elapsed();
                _timer.Dispose();
                _timeValuer = 0;
                _isStarted = false;
                _isElapsed = true;
            }
        }

        public void Dispose()
        {
            _isElapsed = false;
            _isStarted = false;
            _timer.Dispose();
        }

        ~TestTimer()
        {
            Dispose();
        }
    }

    public enum TimerType
    {
        TON = 1,
        TOF = 2,
        AUTOREST = 3,
        RESETWITHKEY = 4
    }
    public enum TimerPeriod
    {
        _1SEC = 1000,
        _100MS = 100,
        _10MS = 10,

    }
}

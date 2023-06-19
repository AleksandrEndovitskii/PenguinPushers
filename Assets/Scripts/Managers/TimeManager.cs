using System;
using PenguinPushers.Extensions;
using UnityEngine;

namespace PenguinPushers.Managers
{
    public class TimeManager : BaseManager<TimeManager>
    {
        public event Action<int> SecondsPassedCountChanged = delegate { };
        public int SecondsPassedCount
        {
            get
            {
                return _secondsPassedCount;
            }
            set
            {
                if (value == _secondsPassedCount)
                {
                    return;
                }

                // Debug.Log("{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                //           $"\n{_secondsPassedCount}->{value}");
                _secondsPassedCount = value;

                SecondsPassedCountChanged.Invoke(_secondsPassedCount);
            }
        }
        private int _secondsPassedCount;

        private Coroutine _secondCountingCoroutine;

        protected override void Initialize()
        {
            RestartTimer();

            IsInitialized = true;
        }

        protected override void UnInitialize()
        {
        }

        protected override void Subscribe()
        {
        }

        protected override void UnSubscribe()
        {
        }

        private void StartTimer()
        {
            this.InvokeActionRepeatedly(() =>
                {
                    SecondsPassedCount++;
                },
                1f);
        }
        private void StopTimer()
        {
            if (_secondCountingCoroutine != null)
            {
                StopCoroutine(_secondCountingCoroutine);
                _secondCountingCoroutine = null;

                SecondsPassedCount = 0;
            }
        }
        private void RestartTimer()
        {
            StopTimer();

            StartTimer();
        }
    }
}

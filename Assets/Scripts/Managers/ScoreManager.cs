using System;
using PenguinPushers.Helpers;
using UnityEngine;

namespace PenguinPushers.Managers
{
    public class ScoreManager : BaseManager<ScoreManager>
    {
        public event Action<int> ScoreChanged = delegate { };
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value == _score)
                {
                    return;
                }

                Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                          $"\n{_score}->{value}");
                _score = value;

                ScoreChanged.Invoke(_score);
            }
        }
        private int _score;

        protected override void Initialize()
        {
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
    }
}

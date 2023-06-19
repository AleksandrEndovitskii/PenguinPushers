using System;
using PenguinPushers.Helpers;
using PenguinPushers.Utils;
using UnityEngine;

namespace PenguinPushers.Managers
{
    public class GameStateManager : BaseManager<GameStateManager>
    {
        public event Action<GameState> GameStateChanged = delegate { };

        public GameState GameState
        {
            get => _gameState;
            set
            {
                if (_gameState == value)
                {
                    return;
                }

                Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                          $"\n{_gameState}->{value}");

                _gameState = value;

                GameStateChanged.Invoke(_gameState);
            }
        }

        private GameState _gameState = GameState.NotStarted;

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

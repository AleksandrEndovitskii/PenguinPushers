using System;
using System.Collections.Generic;
using PenguinPushers.Components.BaseComponents;
using PenguinPushers.Extensions;
using PenguinPushers.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace PenguinPushers.Components.MovementComponents
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveFromTargetComponent : BaseComponent
    {
        [SerializeField]
        public float _moveAwayDistance = 10f;

        public event Action<List<Transform>> TargetChanged = delegate { };
        public List<Transform> Targets
        {
            get => _targets;
            protected set
            {
                if (_targets == value)
                {
                    return;
                }

                Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                          $"\n{_targets}->{value}");

                _targets = value;

                TargetChanged.Invoke(_targets);
            }
        }
        private List<Transform> _targets;

        private NavMeshAgent _navMeshAgent;

        protected override void Initialize()
        {
            _navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();

            this.InvokeActionRepeatedly(() =>
            {
                MoveFromTargetsIfTargetIsTooClose(_targets, _moveAwayDistance);
            }, 0.1f);
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

        protected virtual void MoveFromTargetsIfTargetIsTooClose(List<Transform> targetTransforms, float moveAwayDistance)
        {
            var transformsInRange = new List<Transform>();
            foreach (var targetTransform in targetTransforms)
            {
                transformsInRange.Add(targetTransform);
            }

            var isAnyTargetInRange = transformsInRange.Count != 0;
            if (isAnyTargetInRange)
            {
                var combinedDirectionFromTargetToThis = this.gameObject.transform.GetCombinedDirectionFromTargetToThisNormalized(transformsInRange);

                var targetPosition = transform.position + combinedDirectionFromTargetToThis;

                _navMeshAgent.MoveTo(targetPosition);
            }
            else
            {
                _navMeshAgent.StopMovement();
            }
        }
    }
}

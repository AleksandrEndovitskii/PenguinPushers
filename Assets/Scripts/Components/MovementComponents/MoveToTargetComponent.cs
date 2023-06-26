using System;
using PenguinPushers.Components.BaseComponents;
using PenguinPushers.Extensions;
using PenguinPushers.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace PenguinPushers.Components.MovementComponents
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveToTargetComponent : BaseComponent
    {
        // TODO: replace Transform->GameObject?
        public event Action<Transform> TargetChanged = delegate { };
        public Transform Target
        {
            get => _target;
            protected set
            {
                if (_target == value)
                {
                    return;
                }

                Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                          $"\n{_target}->{value}");

                _target = value;

                TargetChanged.Invoke(_target);
            }
        }
        private Transform _target;

        private NavMeshAgent _navMeshAgent;

        protected override void Initialize()
        {
            _navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();

            this.InvokeActionRepeatedly(() =>
            {
                MoveToTarget(Target);
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

        protected virtual void MoveToTarget(Transform targetTransform)
        {
            if (targetTransform != null)
            {
                var directionFromThisToTarget = this.gameObject.transform.GetDirectionFromThisToTarget(targetTransform);

                var targetPosition = transform.position + directionFromThisToTarget;

                _navMeshAgent.MoveTo(targetPosition);
            }
            else
            {
                StopMovement();
            }
        }
        protected void StopMovement()
        {
            _navMeshAgent.StopMovement();
        }
    }
}

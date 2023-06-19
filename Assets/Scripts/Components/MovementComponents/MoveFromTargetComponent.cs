using PenguinPushers.Components.BaseComponents;
using PenguinPushers.Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace PenguinPushers.Components.MovementComponents
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveFromTargetComponent : BaseComponent
    {
        [SerializeField]
        public Transform _target;
        [SerializeField]
        public float _moveAwayDistance = 10f;

        private NavMeshAgent _navMeshAgent;

        protected override void Initialize()
        {
            _navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
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

        // TODO: replace update by invoking same method every 0.1 seconds
        private void Update()
        {
            var directionFromThisToTarget = this.gameObject.transform.position - _target.position;

            var ifTargetIsTooClose = directionFromThisToTarget.magnitude < _moveAwayDistance;
            if (ifTargetIsTooClose)
            {
                MoveAway(directionFromThisToTarget);
            }
            else
            {
                StopMovement();
            }
        }

        private void MoveAway(Vector3 directionFromThisToTarget)
        {
            var detination = this.gameObject.transform.position +
                             directionFromThisToTarget.normalized * _moveAwayDistance;

            _navMeshAgent.isStopped = true;
            this.InvokeActionAfterFirstFrame(() =>
            {
                _navMeshAgent.SetDestination(detination);
                _navMeshAgent.isStopped = false;
            });
        }
        private void StopMovement()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}
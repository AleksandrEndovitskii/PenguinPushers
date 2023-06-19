using PenguinPushers.Components.BaseComponents;
using UnityEngine;

namespace PenguinPushers.Components.MovementComponents
{
    public class MoveFromTargetComponent : BaseComponent
    {
        [SerializeField]
        public Transform _target;
        [SerializeField]
        public float _moveSpeed = 1f;
        [SerializeField]
        public float _moveAwayDistance = 10f;

        protected override void Initialize()
        {
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

        // TODO: replace this by pathfinding
        private void Update()
        {
            var directionFromThisToTarget = this.gameObject.transform.position - _target.position;

            var ifTargetIsTooClose = directionFromThisToTarget.magnitude < _moveAwayDistance;
            if (ifTargetIsTooClose)
            {
                MoveAway(directionFromThisToTarget);
            }
        }

        private void MoveAway(Vector3 directionFromThisToTarget)
        {
            directionFromThisToTarget.Normalize();

            var desiredPosition = transform.position + directionFromThisToTarget * _moveSpeed * Time.deltaTime;

            transform.position = desiredPosition;
        }
    }
}

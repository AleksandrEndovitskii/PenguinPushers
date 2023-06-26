using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using PenguinPushers.Extensions;
using PenguinPushers.Managers;
using PenguinPushers.Views;
using UnityEngine;

namespace PenguinPushers.Components.MovementComponents
{
    public class MoveToClosestPenguinComponent : MoveToTargetComponent
    {
        private List<PenguinView> _penguinViews;

        protected override async void Initialize()
        {
            base.Initialize();

            await UniTask.WaitUntil(() => PenguinsManager.Instance != null &&
                                          PenguinsManager.Instance.IsInitialized);

            _penguinViews = PenguinsManager.Instance.PenguinViewInstances;
        }

        protected override void MoveToTarget(Transform targets)
        {
            var penguinView = this.gameObject.transform.GetClosest(_penguinViews);

            if (penguinView == null)
            {
                Target = null;
                StopMovement();

                return;
            }

            Target = penguinView.transform;

            base.MoveToTarget(Target);
        }
    }
}

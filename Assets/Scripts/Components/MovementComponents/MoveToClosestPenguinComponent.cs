using System.Collections.Generic;
using System.Linq;
using PenguinPushers.Extensions;
using PenguinPushers.Views;
using UnityEngine;

namespace PenguinPushers.Components.MovementComponents
{
    public class MoveToClosestPenguinComponent : MoveToTargetComponent
    {
        private List<PenguinView> _penguinViews;

        protected override void Initialize()
        {
            base.Initialize();

            _penguinViews = FindObjectsByType<PenguinView>(FindObjectsSortMode.None).ToList();
        }

        protected override void MoveToTarget(Transform targets)
        {
            var penguinView = this.gameObject.transform.GetClosest(_penguinViews);

            Target = penguinView.transform;

            base.MoveToTarget(Target);
        }
    }
}

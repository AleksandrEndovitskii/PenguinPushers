using PenguinPushers.Common;
using PenguinPushers.Components.BaseComponents;
using PenguinPushers.Managers;
using UnityEngine;

namespace PenguinPushers.Components.CollisionDetectionComponents
{
    [RequireComponent(typeof(Collider))]
    public class TriggerDetectionComponent : BaseComponent
    {
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

        private void OnTriggerEnter(Collider otherCollider)
        {
            if (CollisionHandlingManager.Instance == null)
            {
                return;
            }

            var view1 = this.gameObject.GetComponent<IBaseView>();
            var view2 = otherCollider.gameObject.GetComponent<IBaseView>();
            CollisionHandlingManager.Instance.HandleOnTriggerEnter(view1, view2);
        }
        private void OnTriggerExit(Collider otherCollider)
        {
            if (CollisionHandlingManager.Instance == null)
            {
                return;
            }

            var view1 = this.gameObject.GetComponent<IBaseView>();
            var view2 = otherCollider.gameObject.GetComponent<IBaseView>();
            CollisionHandlingManager.Instance.HandleOnTriggerExit(view1, view2);
        }
    }
}

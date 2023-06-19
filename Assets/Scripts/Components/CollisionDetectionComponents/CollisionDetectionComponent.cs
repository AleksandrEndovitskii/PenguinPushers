using PenguinPushers.Components.BaseComponents;
using PenguinPushers.Managers;
using PenguinPushers.Views;
using UnityEngine;

namespace PenguinPushers.Components.CollisionDetectionComponents
{
    [RequireComponent(typeof(Collider))]
    public class CollisionDetectionComponent : BaseComponent
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

        private void OnCollisionEnter(Collision otherCollision)
        {
            if (CollisionHandlingManager.Instance == null)
            {
                return;
            }

            var view1 = this.gameObject.GetComponent<IBaseView>();
            var view2 = otherCollision.gameObject.GetComponent<IBaseView>();
            CollisionHandlingManager.Instance.HandleOnCollisionEnter(view1, view2);
        }
        private void OnCollisionExit(Collision otherCollision)
        {
            if (CollisionHandlingManager.Instance == null)
            {
                return;
            }

            var view1 = this.gameObject.GetComponent<IBaseView>();
            var view2 = otherCollision.gameObject.GetComponent<IBaseView>();
            CollisionHandlingManager.Instance.HandleOnCollisionExit(view1, view2);
        }
    }
}

﻿using System;
using PenguinPushers.Common;
using PenguinPushers.Helpers;
using UnityEngine;

namespace PenguinPushers.Managers
{
    public class CollisionHandlingManager : BaseManager<CollisionHandlingManager>
    {
        public event Action<IBaseView, IBaseView> TriggerEnter = delegate { };
        public event Action<IBaseView ,IBaseView> TriggerExit = delegate { };

        public event Action<IBaseView ,IBaseView> CollisionEnter = delegate { };
        public event Action<IBaseView ,IBaseView> CollisionExit = delegate { };

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

        public void HandleOnTriggerEnter(IBaseView view1, IBaseView view2)
        {
            if (view1 == null ||
                view2 == null)
            {
                return;
            }

            Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                          $"\n{nameof(view1)}={view1.GetType().Name}" +
                          $"\n{nameof(view2)}={view2.GetType().Name}");

            TriggerEnter.Invoke(view1, view2);
        }
        public void HandleOnTriggerExit(IBaseView view1, IBaseView view2)
        {
            if (view1 == null ||
                view2 == null)
            {
                return;
            }

            Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                              $"\n{nameof(view1)}={view1.GetType().Name}" +
                              $"\n{nameof(view2)}={view2.GetType().Name}");

            TriggerExit.Invoke(view1, view2);
        }

        public void HandleOnCollisionEnter(IBaseView view1, IBaseView view2)
        {
            Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                      $"\n{nameof(view1)}={view1.GetType().Name}" +
                      $"\n{nameof(view2)}={view2.GetType().Name}");

            CollisionEnter.Invoke(view1, view2);
        }
        public void HandleOnCollisionExit(IBaseView view1, IBaseView view2)
        {
            Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                      $"\n{nameof(view1)}={view1.GetType().Name}" +
                      $"\n{nameof(view2)}={view2.GetType().Name}");

            CollisionExit.Invoke(view1, view2);
        }
    }
}

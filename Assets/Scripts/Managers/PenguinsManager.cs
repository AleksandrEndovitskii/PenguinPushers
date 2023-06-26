using System;
using System.Collections.Generic;
using PenguinPushers.Helpers;
using PenguinPushers.Views;
using UnityEngine;

namespace PenguinPushers.Managers
{
    public class PenguinsManager : BaseManager<PenguinsManager>
    {
        private List<PenguinView> _penguinViewInstances = new List<PenguinView>();

        public List<PenguinView> PenguinViewInstances => _penguinViewInstances;

        // TODO: Replace by reactive property
        [NonSerialized]
        public int PenguinViewInstancesInitialCount;

        protected override void Initialize()
        {
            PenguinViewInstancesInitialCount = _penguinViewInstances.Count;

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

        public void RegisterInstance(PenguinView penguinView)
        {
            Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                      $"\n{penguinView}=={penguinView}");

            PenguinViewInstances.Add(penguinView);
        }
        public void UnRegisterInstance(PenguinView penguinView)
        {
            Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                      $"\n{penguinView}=={penguinView}");

            PenguinViewInstances.Remove(penguinView);
        }
    }
}

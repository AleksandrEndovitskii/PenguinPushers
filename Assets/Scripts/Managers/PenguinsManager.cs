using System.Collections.Generic;
using System.Linq;
using PenguinPushers.Views;
using UnityEngine;

namespace PenguinPushers.Managers
{
    public class PenguinsManager : BaseManager<PenguinsManager>
    {
        [SerializeField]
        private List<PenguinView> _penguinViewInstances = new List<PenguinView>();

        // TODO: Replace by reactive property
        public int PenguinViewInstancesInitialCount;

        protected override void Initialize()
        {
            // TODO: Replace by dynamic instantiating from prefab
            _penguinViewInstances = FindObjectsByType<PenguinView>(FindObjectsSortMode.None).ToList();

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
    }
}

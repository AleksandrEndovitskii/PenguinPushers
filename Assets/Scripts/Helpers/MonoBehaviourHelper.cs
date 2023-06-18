using UnityEngine;

namespace PenguinPushers.Helpers
{
    public static class MonoBehaviourHelper
    {
        public static T Instantiate<T>() where T : MonoBehaviour
        {
            var gameObject = new GameObject();
            var component = gameObject.AddComponent<T>();
            return component;
        }
    }
}

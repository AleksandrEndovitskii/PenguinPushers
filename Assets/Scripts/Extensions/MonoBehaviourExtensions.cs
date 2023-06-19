using System;
using System.Collections;
using UnityEngine;

namespace PenguinPushers.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static void InvokeActionAfterFirstFrame(this MonoBehaviour monoBehaviour,
            Action action)
        {
            var invokeActionAfterFirstFrameCoroutine =
                monoBehaviour.StartCoroutine(InvokeActionAfterFirstFrameCoroutine(action));
        }

        private static IEnumerator InvokeActionAfterFirstFrameCoroutine(Action action)
        {
            yield return new WaitForEndOfFrame();

            action?.Invoke();
        }
    }
}

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

        public static void InvokeActionRepeatedly(this MonoBehaviour monoBehaviour,
            Action action, float delaySeconds)
        {
            var invokeActionRepeatedlyCoroutine =
                monoBehaviour.StartCoroutine(InvokeActionRepeatedlyCoroutine(action, delaySeconds));
        }

        private static IEnumerator InvokeActionAfterFirstFrameCoroutine(Action action)
        {
            yield return new WaitForEndOfFrame();

            action?.Invoke();
        }

        private static IEnumerator InvokeActionRepeatedlyCoroutine(Action action, float delaySeconds)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(delaySeconds);

                action?.Invoke();
            }
        }
    }
}

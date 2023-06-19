using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PenguinPushers.Extensions
{
    public static class TransformExtensions
    {
        public static float GetDistanceTo(this Transform thisTransform, Transform targetTransform)
        {
            var directionFromThisToTarget = thisTransform.GetDirectionFromThisToTarget(targetTransform);

            var distance = Vector3.Distance(thisTransform.position, targetTransform.position); //directionFromThisToTarget.magnitude;

            return distance;
        }

        public static Vector3 GetDirectionFromTargetToThis(this Transform thisTransform, Transform targetTransform)
        {
            var directionFromTargetToThis = thisTransform.position - targetTransform.position;

            return directionFromTargetToThis;
        }

        public static Vector3 GetDirectionFromThisToTarget(this Transform thisTransform, Transform targetTransform)
        {
            var directionFromThisToTarget = targetTransform.position - thisTransform.position;

            return directionFromThisToTarget;
        }

        public static bool IsTargetInRange(this Transform thisTransform, Transform targetTransform, float range)
        {
            var distanceToTarget = thisTransform.GetDistanceTo(targetTransform);
            var isTargetInRange = distanceToTarget <= range;

            return isTargetInRange;
        }

        public static List<Transform> GetTransformsInRange(this Transform thisTransform, List<Transform> targetTransforms, float range)
        {
            var targetsInRange = targetTransforms.Where(x =>
                thisTransform.IsTargetInRange(x, range)).ToList();

            return targetsInRange;
        }
        public static List<T> GetTransformsInRange<T>(this Transform thisTransform, List<T> targetTransforms, float range) where T : MonoBehaviour
        {
            var result = new List<T>();

            var transforms = new List<Transform>();
            foreach (var target in targetTransforms)
            {
                transforms.Add(target.gameObject.transform);
            }

            var transformsInRange = thisTransform.GetTransformsInRange(transforms, range);
            foreach (var targetInRange in transformsInRange)
            {
                var targetTransform = targetTransforms.FirstOrDefault(x => x.gameObject.transform == targetInRange);
                result.Add(targetTransform);
            }

            return result;
        }

        public static Transform GetClosestTransform(this Transform thisTransform, List<Transform> targetTransforms)
        {
            Transform closestTransform = null;
            var closestDistance = float.MaxValue;

            foreach (var targetTransform in targetTransforms)
            {
                var distance = Vector3.Distance(thisTransform.position, targetTransform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTransform = targetTransform;
                }
            }

            return closestTransform;
        }

        public static T GetClosest<T>(this Transform thisTransform, List<T> targets) where T : MonoBehaviour
        {
            var transforms = new List<Transform>();
            foreach (var target in targets)
            {
                transforms.Add(target.gameObject.transform);
            }
            var closestTransform = thisTransform.GetClosestTransform(transforms);
            // TODO: replace by dictionary
            var closestT = targets.FirstOrDefault(x => x.gameObject.transform == closestTransform);

            return closestT;
        }

        public static Vector3 GetCombinedDirectionFromTargetToThisNormalized(this Transform thisTransform, List<Transform> transforms)
        {
            var combinedDirection = Vector3.zero;
            foreach (var transform in transforms)
            {
                var direction = thisTransform.GetDirectionFromTargetToThis(transform);
                combinedDirection += direction;
            }
            combinedDirection.Normalize();

            return combinedDirection;
        }
    }
}

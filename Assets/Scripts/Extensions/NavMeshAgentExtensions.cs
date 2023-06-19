using UnityEngine;
using UnityEngine.AI;

namespace PenguinPushers.Extensions
{
    public static class NavMeshAgentExtensions
    {
        public static void MoveTo(this NavMeshAgent navMeshAgent, Vector3 destination)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.gameObject.GetComponent<MonoBehaviour>().InvokeActionAfterFirstFrame(() =>
            {
                navMeshAgent.SetDestination(destination);
                navMeshAgent.isStopped = false;
            });
        }
        public static void StopMovement(this NavMeshAgent navMeshAgent)
        {
            navMeshAgent.isStopped = true;
        }
    }
}

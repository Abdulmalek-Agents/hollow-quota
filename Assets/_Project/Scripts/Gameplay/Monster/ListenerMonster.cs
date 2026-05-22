using UnityEngine;
using UnityEngine.AI;
namespace HollowQuota.Monster
{
    public enum ListenerState { Wander, Pursue, Investigate }

    [RequireComponent(typeof(NavMeshAgent))]
    public class ListenerMonster : MonoBehaviour
    {
        [SerializeField] private float pursueDurationSec = 5f;
        [SerializeField] private float wanderRadius = 18f;
        [SerializeField] private float aggression = 1f;
        public ListenerState State { get; private set; }
        private NavMeshAgent _agent;
        private float _stateUntil;
        private Vector3 _lastHeard;

        private void Awake() { _agent = GetComponent<NavMeshAgent>(); State = ListenerState.Wander; }

        public void ReportSound(Vector3 worldPos, float intensity = 1f)
        {
            if (intensity * aggression < 0.5f) return;
            _lastHeard = worldPos;
            State = ListenerState.Pursue;
            _stateUntil = Time.time + pursueDurationSec;
            _agent.SetDestination(worldPos);
        }

        private void Update()
        {
            switch (State)
            {
                case ListenerState.Wander:
                    if (!_agent.hasPath || _agent.remainingDistance < 0.5f) WanderTo();
                    break;
                case ListenerState.Pursue:
                    if (Time.time >= _stateUntil) { State = ListenerState.Investigate; _stateUntil = Time.time + pursueDurationSec; }
                    break;
                case ListenerState.Investigate:
                    if (Time.time >= _stateUntil) State = ListenerState.Wander;
                    break;
            }
        }

        private void WanderTo()
        {
            var p = transform.position + Random.insideUnitSphere * wanderRadius; p.y = transform.position.y;
            if (NavMesh.SamplePosition(p, out var hit, wanderRadius, NavMesh.AllAreas)) _agent.SetDestination(hit.position);
        }
    }
}

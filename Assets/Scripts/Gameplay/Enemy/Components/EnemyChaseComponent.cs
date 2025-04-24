using UnityEngine.AI;

namespace Gameplay
{
    public class EnemyChaseComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly PlayerTransform _target;
        private readonly float _speed;

        public EnemyChaseComponent(PlayerTransform target, NavMeshAgent enemy, float speed)
        {
            _agent = enemy;
            _speed = speed;
            _target = target;
        }

        public void Chase()
        {
            _agent.isStopped = false;

            _agent.SetDestination(_target.Transform.position);
            _agent.speed = _speed;
        }
    }
}
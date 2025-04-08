namespace Gameplay
{
    public class EnemyBehaviour
    {
        private PatrolComponent _patrolState;
        private AttackComponent _attackState;
        private ChaseComponent _chaseState;

        public EnemyBehaviour(PatrolComponent patrolState, AttackComponent attackState,
            ChaseComponent chaseState)
        {
            _patrolState = patrolState;
            _attackState = attackState;
            _chaseState = chaseState;
        }

        public void Patrol() => _patrolState.Patrol();

        public void Chase() => _chaseState.Chase();

        public void Attack() => _attackState.Attack();
    }
}
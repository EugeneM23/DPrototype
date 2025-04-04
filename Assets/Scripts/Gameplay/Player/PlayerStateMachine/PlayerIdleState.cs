using UnityEngine;

namespace Gameplay
{
    public class PlayerIdleState : IPlayerState
    {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Player _player;
        private Enemy[] _enemies;
        private float _sootRangeDistance = 6;

        public PlayerIdleState(PlayerStateMachine stateMachine,  Player player, Enemy[] enemies,
            PlayerParameters parameters)
        {
            _stateMachine = stateMachine;
            _player = player;
            _enemies = enemies;
            _sootRangeDistance = parameters.AimingDistance;
        }

        public void Enter()
        {
            Debug.Log("Idle State");
        }

        public void Exit()
        {
            Debug.Log("Exit Idle");
        }

        public void Update()
        {
            if (_player.GetVelocity() != Vector3.zero ) 
                _stateMachine.SetState<PlayerMoveState>();

            
            if (CalculateDistance() < _sootRangeDistance)
                _stateMachine.SetState<PlayerFireState>();
        }

        private float CalculateDistance()
        {
            Enemy closest = null;
            float minDistance = Mathf.Infinity;

            foreach (var item in _enemies)
            {
                foreach (Enemy t in _enemies)
                {
                    float distance = Vector3.Distance(_player.transform.position, t.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closest = t;
                    }
                }
            }

            return minDistance;
        }
    }
}
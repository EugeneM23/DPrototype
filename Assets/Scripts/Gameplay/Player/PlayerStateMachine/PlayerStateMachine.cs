using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay.Player
{
    public class PlayerStateMachine : ITickable, IInitializable
    {
        private readonly Dictionary<Type, IPlayerState> _states = new();
        private IPlayerState _currentState;

        public PlayerStateMachine(Player player, PlayerInput playerInput, Enemy[] enemys)
        {
            _states = new Dictionary<Type, IPlayerState>()
            {
                [typeof(PlayerMoveState)] = new PlayerMoveState(this, playerInput, player),
                [typeof(PlayerIdleState)] = new PlayerIdleState(this, playerInput, player, enemys),
                [typeof(PlayerFireState)] = new PlayerFireState(this, playerInput, player, enemys),
            };
        }

        public void Initialize()
        {
            _currentState = _states[typeof(PlayerIdleState)];
        }

        public void Tick()
        {
            _currentState.Update();
        }

        public void SetState<T>() where T : IPlayerState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(T)];
            _currentState.Enter();
        }
    }
}
using System;
using Game;
using Gameplay;
using Gameplay.Modules;
using Modules;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemySetings _enemySetings;
        [Inject] private readonly Transform _enemyTransform;
        [Inject] private readonly PlayerTransform _playerTransform;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Enemy>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EnemyPatrolPointManager>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EnemyAttackAssistComponent>()
                .AsSingle().WithArguments(_enemyTransform, _playerTransform.Transform, _enemySetings.AttakRotationSpeed)
                .NonLazy();

            Container
                .Bind<EnemyDamageComponent>()
                .AsSingle()
                .WithArguments(_enemySetings.Damage)
                .NonLazy();


            EnemyHealthInstaller.Install(Container);
            EnemyStateInstaller.Install(Container, _enemySetings);
            EnemyAnimationInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<EnemyTakeDamageController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyImpulseComponent>().AsSingle().NonLazy();
        }
    }

    public class EnemyImpulseComponent : ITickable
    {
        private readonly Rigidbody _rigidbody;
        private float _impulseTime = 0.1f;
        private float _timer = 0;

        private bool IsImpulse = false;

        public EnemyImpulseComponent(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void SetImpulse()
        {
            _timer = _impulseTime;
        }

        public void Tick()
        {
            if (_timer <= 0) return;

            _timer -= Time.deltaTime;
            if (_timer > 0)
            {
                if (IsImpulse == false)
                {
                    IsImpulse = true;
                    _rigidbody.isKinematic = false;
                    _rigidbody.AddForce(-_rigidbody.transform.forward * 50, ForceMode.Impulse);
                    Debug.Log($"Impulse: {_rigidbody.transform.forward}");
                }
            }
            else
            {
                IsImpulse = false;
                _rigidbody.isKinematic = true;
            }
        }
    }

    public class EnemyTakeDamageController : IInitializable
    {
        private readonly EnemyImpulseComponent _impulseComponent;
        private readonly HealthComponentBase _healthComponent;

        public EnemyTakeDamageController(EnemyImpulseComponent impulseComponent, HealthComponentBase healthComponent)
        {
            _impulseComponent = impulseComponent;
            _healthComponent = healthComponent;
        }

        public void Initialize()
        {
            _healthComponent.OnHit += () => _impulseComponent.SetImpulse();
        }
    }
}
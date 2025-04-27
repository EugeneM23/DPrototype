using Gameplay.Modules;
using Zenject;

namespace Gameplay
{
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
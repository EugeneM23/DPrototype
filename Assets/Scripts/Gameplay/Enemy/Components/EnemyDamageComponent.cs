namespace Gameplay
{
    internal class EnemyDamageComponent
    {
        private readonly int _damge;

        public EnemyDamageComponent(int damge) => _damge = damge;

        public int Damage => _damge;
    }
}
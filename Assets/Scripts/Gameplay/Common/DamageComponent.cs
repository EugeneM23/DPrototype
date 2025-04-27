namespace Gameplay
{
    internal class DamageComponent
    {
        private readonly int _damge;

        public DamageComponent(int damge) => _damge = damge;

        public int Damage => _damge;
    }
}
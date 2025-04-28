namespace Gameplay
{
    public class BulletDamageComponent
    {
        private int _damage;

        public int Damage => _damage;

        public BulletDamageComponent(int damage)
        {
            _damage = damage;
        }

        public void SetDamage(int damage) => _damage = damage;
    }
}
namespace Gameplay
{
    public class BulletDamageComponent
    {
        private int _damage;
        private float _impulse;

        public int Damage => _damage;

        public BulletDamageComponent(int damage, float impulse)
        {
            _damage = damage;
            _impulse = impulse;
        }

        public void SetDamage(int damage) => _damage = damage;
    }
}
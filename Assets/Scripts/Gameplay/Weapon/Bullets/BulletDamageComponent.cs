namespace Gameplay
{
    public class BulletDamageComponent
    {
        private int _damage;

        public int Damage => _damage;

        public void SetDamage(int damage) => _damage = damage;
    }
}
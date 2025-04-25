using Zenject;

namespace Game
{
    public class WeaponFireController : IInitializable
    {
        private readonly Player _player;
        private readonly Weapon _weapon;

        public WeaponFireController(Player player, Weapon weapon)
        {
            _player = player;
            _weapon = weapon;
        }

        public void Initialize()
        {
            _player.OnShoot += _weapon.Shoot;
        }
    }
}
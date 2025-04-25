namespace Gameplay
{
    public class PlayerWeponController
    {
        private Weapon _weapon;
        private Player _player;

        public void SetWeaponToPlayer()
        {
            _player.SetWeapon(_weapon);
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
        }
    }
}
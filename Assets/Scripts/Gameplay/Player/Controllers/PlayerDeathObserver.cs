using Modules;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class PlayerDeathObserver : DeathObserver
    {
        public PlayerDeathObserver(HealthComponent health) : base(health)
        {
        }

        public override void Death(HealthComponent obj)
        {
            SceneManager.LoadScene("L_Base");
        }
    }
}
using UnityEngine;

namespace Gameplay
{
    public class PlayerHitEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public void Hit() => _particleSystem.Play();
    }
}
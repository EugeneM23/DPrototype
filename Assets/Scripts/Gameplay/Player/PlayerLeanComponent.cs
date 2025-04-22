using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerLeanComponent : ITickable
    {
        private readonly PlayerTransform _player;
        private float leanAmount = 20f;
        private float leanSpeed = 7f;

        private Vector3 lastForward;
        private float currentLean = 0f;

        public PlayerLeanComponent(PlayerTransform player)
        {
            _player = player;
        }

        public void Tick()
        {
            Lean();
        }

        private void Lean()
        {
            Vector3 currentForward = _player.Player.forward;
            Vector3 cross = Vector3.Cross(lastForward, currentForward);
            float angle = Vector3.SignedAngle(lastForward, currentForward, Vector3.up);
            float angularSpeed = angle / Time.deltaTime;

            // Определяем, в какую сторону поворачиваем и насколько сильно
            float targetLean = Mathf.Clamp(-angularSpeed / 200f * leanAmount, -leanAmount, leanAmount);

            currentLean = Mathf.Lerp(currentLean, targetLean, Time.deltaTime * leanSpeed);

            Quaternion leanRotation = Quaternion.Euler(0f, 0f, currentLean);
            _player.Player.localRotation = Quaternion.Euler(0f, _player.Player.eulerAngles.y, 0f) * leanRotation;

            lastForward = currentForward;
        }
    }
}
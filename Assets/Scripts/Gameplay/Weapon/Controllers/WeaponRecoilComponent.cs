using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class WeaponRecoilComponent : IInitializable
    {
        private readonly PlayerWeaponBoneTransform _weaponBone;
        private Vector3 _originalLocalPosition;

        public WeaponRecoilComponent(PlayerWeaponBoneTransform weaponBone)
        {
            _weaponBone = weaponBone;
        }

        public void Initialize()
        {
            _originalLocalPosition = _weaponBone.WeaponBone.localPosition;
        }

        public void Recoil(float distance = 1f, float duration = 0.05f, float returnDuration = 0.1f)
        {
            // Прерываем текущие твины
            _weaponBone.WeaponBone.DOKill();

            // Отдача назад (вдоль локальной -Z оси)
            Vector3 recoilOffset = _originalLocalPosition + -_weaponBone.WeaponBone.up * distance;

            _weaponBone.WeaponBone.DOLocalMove(recoilOffset, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    // Возврат в исходную позицию
                    _weaponBone.WeaponBone.DOLocalMove(_originalLocalPosition, returnDuration).SetEase(Ease.OutQuad);
                });
        }
    }
}
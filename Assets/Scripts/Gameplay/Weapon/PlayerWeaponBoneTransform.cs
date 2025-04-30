using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerWeaponBoneTransform : MonoBehaviour
    {
        [SerializeField] private Transform _weaponBone;
        [SerializeField] private float _recoilDistance = 40f;
        [SerializeField] private float _recoilDuration = 0.1f;
        [SerializeField] private float _returnDuration = 0.1f;

        [Inject] private readonly Weapon _weapon;
        public Transform WeaponBone => _weaponBone;

        private Vector3 _originalLocalPosition;
        private Tween _currentRecoilTween;

        private void OnEnable()
        {
            _originalLocalPosition = _weaponBone.localPosition;
            _weapon.OnFire += Recoil;
        }

        private void OnDisable()
        {
            _weapon.OnFire -= Recoil;
        }

        private void Recoil()
        {
            // Прервать текущую анимацию, если она активна
            _currentRecoilTween?.Kill();

            // Сбросить в начальную позицию
            _weaponBone.localPosition = _originalLocalPosition + _weaponBone.forward;

            // Вычислить позицию отдачи
            Vector3 recoilPosition = _originalLocalPosition + Vector3.back * _recoilDistance;

            // Создать новую последовательность отдачи
            _currentRecoilTween = DOTween.Sequence()
                .Append(_weaponBone.DOLocalMove(recoilPosition, _recoilDuration))
                .Append(_weaponBone.DOLocalMove(_originalLocalPosition, _returnDuration));
        }
    }
}
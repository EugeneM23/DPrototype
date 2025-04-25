using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class HPBarInstaller : Installer<Vector3, Transform, HPBar, HPBarInstaller>
    {
        [Inject] private HPBar _hpBar;
        [Inject] private Transform _parent;
        [Inject] private Vector3 _hpBarOffset;

        public override void InstallBindings()
        {
            Container
                .Bind<HPBar>()
                .FromComponentInNewPrefab(_hpBar)
                .UnderTransform(_parent)
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerHPBarPComponent>()
                .AsSingle().WithArguments(_hpBarOffset, _parent)
                .NonLazy();
        }
    }
}
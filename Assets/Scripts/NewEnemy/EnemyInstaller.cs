using Gameplay;
using NewEnemy;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private HPBar _hpBar;
    [SerializeField] private Vector3 _hpBarOffset;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<EnemyTakeDamageController>()
            .AsSingle()
            .NonLazy();

      //  HPBarInstaller.Install(Container, _hpBarOffset, gameObject.transform, _hpBar);
    }
}
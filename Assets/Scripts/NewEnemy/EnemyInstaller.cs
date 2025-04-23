using Gameplay;
using NewEnemy;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private HPBar _hpBar;

    public override void InstallBindings()
    {
        Container
            .Bind<HPBar>()
            .FromComponentInNewPrefab(_hpBar)
            .UnderTransform(gameObject.transform)
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<EnemyTakeDamageController>()
            .AsSingle()
            .NonLazy();
    }
}
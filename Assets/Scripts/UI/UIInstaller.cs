using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private GameObject _HUD;

    public override void InstallBindings()
    {
        Instantiate(_HUD);
    }
}
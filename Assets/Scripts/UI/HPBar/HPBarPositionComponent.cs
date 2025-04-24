using Gameplay;
using UnityEngine;
using Zenject;

public class HPBarPositionComponent : ITickable, IInitializable
{
    private readonly HPBar _healthBar;
    private readonly Transform _parent;
    private readonly Vector3 _offset;
    private Camera _camera;

    public HPBarPositionComponent(HPBar healthBar, Vector3 offset, Transform parent)
    {
        _healthBar = healthBar;
        _offset = offset;
        _parent = parent;
        _camera = Camera.main;
    }

    public void Tick()
    {
        Vector3 directionToCamera = _camera.transform.position - _healthBar.transform.position;

        directionToCamera.x = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        _healthBar.transform.rotation = targetRotation;
        _healthBar.transform.position = _parent.transform.position + _offset;
    }

    public void Initialize()
    {
        //_healthBar.transform.SetParent(null);
    }
}
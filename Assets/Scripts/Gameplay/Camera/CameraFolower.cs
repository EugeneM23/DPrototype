using UnityEngine;
using Zenject;
using System.Linq;
using Gameplay;

public class CameraFollower : ILateTickable
{
    private readonly Player _target;
    private readonly Transform _camera;
    private readonly Vector3 _offset;
    private readonly float _smoothTime = 0.15f;
    private Vector3 _velocity = Vector3.zero;

    public CameraFollower(Transform camera, Player target)
    {
        _camera = camera;
        _target = target;

        if (Camera.main != null)
            _offset = _camera.position - _target.transform.position;
    }

    public void LateTick()
    {
        Vector3 targetPosition = _target.transform.position + _offset;
        _camera.position = Vector3.SmoothDamp(_camera.position, targetPosition, ref _velocity, _smoothTime);
    }
}
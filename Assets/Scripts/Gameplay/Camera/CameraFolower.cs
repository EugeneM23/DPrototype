using UnityEngine;
using Zenject;
using System.Linq;
using Gameplay;

public class CameraFollower : ILateTickable
{
    /*private readonly Player _target;
    private readonly Transform _camera;
    private readonly Vector3 _baseOffset;
    private readonly float _smoothTime = 0.15f;
    private Vector3 _velocity = Vector3.zero;

    private float _currentTiltX;
    private float _tiltVelocity;

    private Vector3 _initialLocalPos;
    private Quaternion _initialLocalRot;

    private const float MaxHeight = 1f;
    private const float MaxTiltAngle = 60f;
    private const float TriggerDistance = 30f;
    private const float TiltSmoothTime = 0.1f; // <- можно сделать публичным, если хочешь менять извне

    [Inject] private readonly EnemyManager _manager;

    public CameraFollower(Transform camera, Player target)
    {
        _camera = camera;
        _target = target;
        _baseOffset = UnityEngine.Camera.main.transform.position - _target.transform.position;

        _initialLocalPos = camera.localPosition;
        _initialLocalRot = camera.localRotation;

        _currentTiltX = _initialLocalRot.eulerAngles.x;
    }

    public void LateTick()
    {
        float influence = 0f;

        foreach (var enemy in _manager.GetAllEnemies())
        {
            if (enemy == null) continue;

            Vector3 toEnemy = enemy.transform.position - _target.transform.position;
            toEnemy.y = 0;

            float cos = Vector3.Dot(Vector3.forward, toEnemy.normalized);
            float distance = toEnemy.magnitude;

            if (cos < 0 && distance < TriggerDistance)
            {
                float t = distance / TriggerDistance;
                influence = Mathf.Max(influence, t); // берём наибольшее влияние от всех врагов
            }
        }

        // Смещение и угол по влиянию
        float targetHeight = MaxHeight * influence;
        float targetTiltX = Mathf.Lerp(_initialLocalRot.eulerAngles.x, MaxTiltAngle, influence);

        // Плавное движение камеры
        Vector3 targetOffset = _baseOffset + new Vector3(0, targetHeight, 0);
        Vector3 targetPosition = _target.transform.position + targetOffset;
        _camera.position = Vector3.SmoothDamp(_camera.position, targetPosition, ref _velocity, _smoothTime);

        // Плавный наклон по X
        _currentTiltX = Mathf.SmoothDampAngle(_currentTiltX, targetTiltX, ref _tiltVelocity, TiltSmoothTime);
        Vector3 currentEuler = _camera.localRotation.eulerAngles;
        _camera.localRotation = Quaternion.Euler(_currentTiltX, currentEuler.y, currentEuler.z);*/

    private readonly Player _target;
    private readonly Transform _camera;
    private readonly Vector3 _offset;
    private readonly float _smoothTime = 0.15f;
    private Vector3 _velocity = Vector3.zero;

    [Inject] private readonly EnemyManager _manager;

    public CameraFollower(Transform camera, Player target)
    {
        _camera = camera;
        _target = target;
        _offset = UnityEngine.Camera.main.transform.position - _target.transform.position;
    }

    public void LateTick()
    {
        Vector3 targetPosition = _target.transform.position + _offset;
        _camera.position = Vector3.SmoothDamp(_camera.position, targetPosition, ref _velocity, _smoothTime);
    }
}
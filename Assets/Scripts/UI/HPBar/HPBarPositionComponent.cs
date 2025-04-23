using Gameplay;
using UnityEngine;
using Zenject;

public class HPBarPositionComponent : MonoBehaviour
{
    [SerializeField] private RectTransform _healthBar;

    private Transform _target => transform.parent;
    private Vector3 _offset;

    private void Start()
    {
        _offset = _healthBar.position - _target.position + -_target.forward * 2;
    }

    void Update()
    {
        transform.position = _offset + _target.transform.position;
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
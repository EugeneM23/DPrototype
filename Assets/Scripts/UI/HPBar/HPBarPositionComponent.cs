using Gameplay;
using UnityEngine;
using Zenject;

public class HPBarPositionComponent : MonoBehaviour
{
    [Inject] private Player _target;
    [SerializeField] private RectTransform _healthBar;
    private Vector3 _offset;

    private void Start()
    {
        _offset = _healthBar.position - _target.transform.position + -_target.transform.forward * 2;
    }

    void Update()
    {
        transform.position = _offset + _target.transform.position;
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
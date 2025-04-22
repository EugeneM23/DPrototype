using Gameplay;
using UnityEngine;
using Zenject;

public class HPBarPositionComponent : MonoBehaviour
{
    [Inject] private PlayerTransform _target;
    [SerializeField] private RectTransform _healthBar;
    private Vector3 _offset;

    private void Start()
    {
        _offset = _healthBar.position - _target.Player.position + -_target.Player.forward * 2;
    }

    void Update()
    {
        transform.position = _offset + _target.transform.position;
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
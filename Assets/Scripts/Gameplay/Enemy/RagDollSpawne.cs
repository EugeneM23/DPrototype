using System;
using Gameplay.Modules;
using UnityEngine;
using Zenject;

public class RagDollSpawne : MonoBehaviour
{
    [SerializeField] private GameObject _dollPrefab;

    [Inject] private readonly HealthComponentBase _healthComponent;

    private void OnEnable()
    {
        _healthComponent.OnDespawn += Spawn;
    }

    private void OnDisable()
    {
        _healthComponent.OnDespawn -= Spawn;
    }

    private void Spawn(HealthComponentBase obj)
    {
        var go = Instantiate(_dollPrefab, transform.position, transform.rotation);

        // Определяем направление и силу импульса
        Vector3 impulseDirection = -transform.forward + Vector3.up; // можно кастомизировать
        float impulseForce = 30f; // сила импульса

        // Получаем все Rigidbody в регдолле
        Rigidbody[] rigidbodies = go.GetComponentsInChildren<Rigidbody>();

        foreach (var rb in rigidbodies)
        {
            rb.AddForce(impulseDirection.normalized * impulseForce, ForceMode.Impulse);
            rb.AddTorque(impulseDirection.normalized * impulseForce, ForceMode.Impulse);
        }
    }
}
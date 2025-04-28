using System.Collections;
using Gameplay;
using UnityEngine;
using Zenject;

public class Flipper : MonoBehaviour
{
    [Inject] private readonly Weapon _weapon;
    [SerializeField] private Light _light;

    private void OnEnable() => _weapon.OnFire += TurOn;

    private void OnDisable() => _weapon.OnFire -= TurOn;

    private void TurOn()
    {
        StartCoroutine(nameof(TurnOnLight));
    }

    private IEnumerator TurnOnLight()
    {
        _light.intensity = 20;
        yield return new WaitForSeconds(_weapon.FireRate);
        _light.intensity = 0;
    }
}
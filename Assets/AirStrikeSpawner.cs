using Gameplay;
using UnityEngine;
using Zenject;

public class AirStrikeSpawner : MonoBehaviour
{
    [Inject] private readonly Player _player;
    [Inject] private readonly BossAirStrikeAttack _airStrike;
    
    public void Spawn()
    {
        _airStrike.gameObject.SetActive(true);
        _airStrike.transform.position = _player.transform.position;
    }
}

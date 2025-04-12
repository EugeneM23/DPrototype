using Gameplay;
using UnityEngine;
using Zenject;

public class AirStrikeSpawner : MonoBehaviour
{
    [Inject] private readonly Player _player;
    [SerializeField] private GameObject _airStrikePrefab;

    public void Spawn()
    {
        var go = Instantiate(_airStrikePrefab);
        var position = _player.transform.position;
        position.y = 0;
        go.transform.position = position;
    }
}
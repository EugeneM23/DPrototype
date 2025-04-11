using System.Collections;
using Gameplay;
using UnityEngine;
using Zenject;

internal class BossAirStrikeAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToPlace;
    [Inject] private readonly Player _player;
    public float radius = 10;

    private void OnEnable()
    {
        StartCoroutine(ASD());
        transform.SetParent(null);
        transform.position = _player.transform.position;

        foreach (GameObject obj in objectsToPlace)
        {
            Vector2 randomCircle = Random.insideUnitCircle * radius;
            Vector3 randomPosition = new Vector3(randomCircle.x, 0, randomCircle.y);
            obj.transform.position = _player.transform.position + randomPosition;
        }
    }

    private IEnumerator ASD()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
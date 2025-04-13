using System.Collections;
using Gameplay;
using UnityEngine;
using Zenject;

internal class BossAirStrikeAttack : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToPlace;
    public float radius = 10;

    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
        StartCoroutine(LifeRoutine());

        foreach (GameObject obj in objectsToPlace)
        {
            Vector2 randomCircle = Random.insideUnitCircle * radius;
            Vector3 randomPosition = new Vector3(randomCircle.x, 0, randomCircle.y);
            obj.transform.position = randomPosition;
        }
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(0.3f);

        while (true)
        {
            foreach (GameObject obj in objectsToPlace)
            {
                yield return new WaitForSeconds(0.1f);
                obj.GetComponent<Animation>().Play("AirStrike");
            }
        }
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
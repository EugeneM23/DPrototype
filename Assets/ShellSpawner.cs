using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _shellPrefab;

    public void Spawn(Transform weaponFirePoint)
    {
        var asd = Instantiate(_shellPrefab, weaponFirePoint.position, Quaternion.identity);
        asd.GetComponent<Rigidbody>().linearVelocity = (Vector3.up * 6 + Vector3.right + Random.insideUnitSphere);
        asd.GetComponent<Rigidbody>().angularVelocity = new Vector3(10, 10, 10);
    }
}
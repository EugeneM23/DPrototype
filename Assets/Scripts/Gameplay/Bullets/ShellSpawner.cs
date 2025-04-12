using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _shellPrefab;

    public void Spawn(Transform weaponFirePoint)
    {
        var asd = Instantiate(_shellPrefab, weaponFirePoint.position, Quaternion.identity);
        var zxc = weaponFirePoint.up + weaponFirePoint.right;
        asd.GetComponent<Rigidbody>().linearVelocity = zxc * 6 + Random.insideUnitSphere;
        asd.GetComponent<Rigidbody>().angularVelocity = new Vector3(10, 10, 10);
    }
}
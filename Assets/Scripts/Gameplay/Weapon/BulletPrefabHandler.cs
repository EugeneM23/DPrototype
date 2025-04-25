using Gameplay;
using UnityEngine;

public class BulletPrefabHandler : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    public Bullet BulletPrefab => _bulletPrefab;
}
using Gameplay;
using UnityEngine;
using Zenject;

public class RangeAttackComponent : MonoBehaviour
{
    [SerializeField] private ParabolaShoot _projectilePrefab;
    [SerializeField] private Transform _firePoint;

    [Inject] private readonly Transform _player;

    public void Fire()
    {
        ParabolaShoot projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        projectile.Construct(_firePoint.position, _player.position);
    }
}
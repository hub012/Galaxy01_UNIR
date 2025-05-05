using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyProjectilePool : MonoBehaviour
{
    [SerializeField] private EnemyProjectile enemyProjectilePrefab;
    private ObjectPool<EnemyProjectile> _enemyProjectilePool;

    public static EnemyProjectilePool Instance; 
    private void Awake()
    {
        Instance = this;
        _enemyProjectilePool = new ObjectPool<EnemyProjectile>(CreateProjectile, OnTakeProjectile, OnReleaseProjectile);
    }

    private EnemyProjectile CreateProjectile()
    {
        EnemyProjectile enemyProjectilePool = Instantiate(enemyProjectilePrefab);
        enemyProjectilePool.EnemyProjectilePool = _enemyProjectilePool; // Assign pool
        enemyProjectilePool.gameObject.SetActive(false);
        return enemyProjectilePool;
    }

    private void OnTakeProjectile(EnemyProjectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }

    private void OnReleaseProjectile(EnemyProjectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    public EnemyProjectile GetProjectile()
    {
        return _enemyProjectilePool.Get();
    }
}

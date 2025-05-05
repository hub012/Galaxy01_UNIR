using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance { get; private set; }
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] public bool CanUseSuperShoot { get; set; }
    private ObjectPool<Projectile> pool;
    private void Awake()
    {
        Instance = this;
        pool = new ObjectPool<Projectile>(CreateProjectile, GetProjectile, ReleaseProjectile);
    }

    private Projectile CreateProjectile()
    {
        Projectile projectileCopia = Instantiate(projectilePrefab,firePoint.position,Quaternion.identity);
        projectileCopia.ProjectilePool = pool;
        return projectileCopia;
    }
    private void GetProjectile(Projectile projectile)
    { 
        projectile.CanUseSuperShoot = CanUseSuperShoot;
        projectile.transform.position = firePoint.position;
        projectile.gameObject.SetActive(true);
    }
    private void ReleaseProjectile(Projectile projectile)
    {
       projectile.gameObject.SetActive(false);
    }
    
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
     {
         pool.Get();
        AudioSource.PlayClipAtPoint(shootSound.clip, transform.position);
     }
    }
}

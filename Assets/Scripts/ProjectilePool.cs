using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    
    private ObjectPool<Projectile> pool;
    private void Awake()
    {
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
            projectile.transform.position = firePoint.position;
            projectile.gameObject.SetActive(true);
         }
    private void ReleaseProjectile(Projectile projectile)
    {
       projectile.gameObject.SetActive(false);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
     //Debug.Log(pool);
     if (Input.GetKeyDown(KeyCode.Space))
     {
         pool.Get();
     }
    }
}

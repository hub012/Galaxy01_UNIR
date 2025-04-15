using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private ObjectPool<Projectile> projectilePool;
    
    public ObjectPool<Projectile> ProjectilePool { get => projectilePool; set => projectilePool = value; }

  /*  public ObjectPool<Projectile> getProjectilePool()
    {
        return projectilePool;
    }
    public void setProjectilePool(ObjectPool<Projectile> value)
    {
        projectilePool = value;
    }*/
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * (velocidad * Time.deltaTime) );
        
        timer += Time.deltaTime;
        // TODO: agregar mejor un collider y cambiar esto
        if (timer >= 4)
        {
            timer = 0;
            projectilePool.Release(this);
        }
    }
}
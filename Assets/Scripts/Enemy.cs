using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private ObjectPool<Enemy> _enemyPool; //variable
    [SerializeField] private AudioSource enemyExplosion;
    [SerializeField] private GameObject _enemyExplosionPrefab;
    [SerializeField] private Transform firePoint;
    //[SerializeField] private float speed = 5.0f;
    [SerializeField] private float damageValue;
    [SerializeField]private int health = 2;
    public static event Action OnPlayerScoreChanged;
    
    public ObjectPool<Enemy> EnemyPool { get => _enemyPool; set => _enemyPool = value; } 
    
    private float releaseTimer;
    private int releaseTimerLimit = 6;
    private float shootTimer;
    private int shootTimerLimit = 1;
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * (-1 * (velocidad * Time.deltaTime)) );
      
        releaseTimer += Time.deltaTime;
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootTimerLimit)
        {
            shootTimer = 0;
            Shoot();
        }
        if (releaseTimer >= releaseTimerLimit)
        {
            releaseTimer = 0;
            _enemyPool.Release(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            AudioSource.PlayClipAtPoint(enemyExplosion.clip, transform.position);
            ReturnEnemyToPool();
            other.gameObject.GetComponent<Player>().TakeDamage(damageValue);
        }
    }

    private void Shoot()
{
    EnemyProjectile projectile = EnemyProjectilePool.Instance.GetProjectile();
    projectile.transform.position = firePoint.position;
    projectile.Initialize(Vector3.left); 
}


    public void TakeDamage()
    {   
        health--;
        
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(enemyExplosion.clip, transform.position);

            OnPlayerScoreChanged?.Invoke();
            ReturnEnemyToPool();
        }
    }

    private void ReturnEnemyToPool()
    {
        releaseTimer = 0; // Reseteo de timer
        health = 2;
        Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
        _enemyPool.Release(this);
    }
}

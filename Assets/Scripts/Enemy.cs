using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private ObjectPool<Enemy> _enemyPool; //variable

    [SerializeField] private GameObject _enemyExplosionPrefab;
    //[SerializeField] private float speed = 5.0f;
    
    public ObjectPool<Enemy> EnemyPool { get => _enemyPool; set => _enemyPool = value; } //struct getter setter
    
    private float releaseTimer;
    private int releaseTimerLimit = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * (-1 * (velocidad * Time.deltaTime)) );
      
        releaseTimer += Time.deltaTime;
        
        if (releaseTimer >= releaseTimerLimit)
        {
            releaseTimer = 0;
            _enemyPool.Release(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _enemyPool.Release(this);
        Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
    }
}

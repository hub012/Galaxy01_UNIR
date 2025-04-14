using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class EnemyPool : MonoBehaviour
    
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    
    private ObjectPool<Enemy> _enemyPool;
    private float spawnTimer;
    [SerializeField] private int spawnTimerLimit;
    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(CreateEnemy, GetEnemy, ReleaseEnemyS);
    }

    private Enemy CreateEnemy()
    {
        
        
        Enemy enemyCopia = Instantiate(enemyPrefab,spawnPoint.position ,Quaternion.identity);
        enemyCopia.EnemyPool = _enemyPool;
        return enemyCopia;
    }
    private void GetEnemy(Enemy enemy)
    {
        int randomPositionY = Random.Range(-4, 4);
        enemy.transform.position = spawnPoint.position+ new Vector3(0, randomPositionY, 0);
        enemy.gameObject.SetActive(true);
    }
    
    private void ReleaseEnemyS(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }
    
    /* private Enemy CreateEnemy ()
    {
        Enemy enemyCopia = Instantiate(enemyprefab,firePoint.position,Quaternion.identity);
        enemyCopia._MyPool = _pool;
        return enemyCopia;
    }*/
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
       //var timer += Time.deltaTime;
       
       spawnTimer += Time.deltaTime;
        
       if (spawnTimer >= spawnTimerLimit)
       {
           spawnTimer = 0;
           _enemyPool.Get();
       }
    }
}

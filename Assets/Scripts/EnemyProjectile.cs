using UnityEngine;
using UnityEngine.Pool;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 direction;
    public ObjectPool<EnemyProjectile> EnemyProjectilePool { get; set; }
    [SerializeField] private float damageValue;

    public void Initialize(Vector3 shootDirection)
    {
        direction = shootDirection.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (transform.position.x <= -15)
            OnBecameInvisible();
    }


    private void OnBecameInvisible()
    {
        if (EnemyProjectilePool != null)
            EnemyProjectilePool.Release(this);
        else
            Destroy(gameObject);
    }

   /*    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            EnemyProjectilePool.Release(this);  
            other.gameObject.GetComponent<Player>().TakeDamage(damageValue);
        }
    } */
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            EnemyProjectilePool.Release(this);  
            collision.gameObject.GetComponent<Player>().TakeDamage(damageValue);
        }
    }
}

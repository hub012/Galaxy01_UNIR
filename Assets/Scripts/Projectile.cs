using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private ObjectPool<Projectile> projectilePool;
    [SerializeField] private GameObject shoot1;
    [SerializeField] private GameObject shoot2;
    [SerializeField] public bool CanUseSuperShoot { get; set; }
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
        if (CanUseSuperShoot)
        {
            shoot2.SetActive(true);
            shoot1.SetActive(false);
        }
        else
        {
            shoot2.SetActive(false);
            shoot1.SetActive(true);
        }
        
        timer += Time.deltaTime;
        // TODO: agregar mejor un collider y cambiar esto
        if (timer >= 4)
        {
            timer = 0;
            projectilePool.Release(this);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        projectilePool.Release(this);
        if (other.gameObject.tag.Equals("Enemy"))
        {  
            other.gameObject.GetComponent<Enemy>().TakeDamage();
        }
    }
}
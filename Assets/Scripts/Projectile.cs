using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private ObjectPool<Projectile> myPool;
    
    public ObjectPool<Projectile> MyPool { get => myPool; set => myPool = value; }
    
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * velocidad * Time.deltaTime );
        
        timer += Time.deltaTime;

        if (timer >= 4)
        {
            timer = 0;
            myPool.Release(this);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private float currentHealth = 100.0f;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private UIWeaponUpgrade _uiWeaponUpgrade;
    public static event Action<float> OnPlayerHealthChanged;
    
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * (horizontal * (speed * Time.deltaTime)));
        transform.Translate(Vector2.up * (vertical * (speed * Time.deltaTime)));
            
       /* if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           //transform.Translate(new Vector2(0,1));
           transform.Translate(Vector2.up * (speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.Translate(new Vector2(0,-1));
            transform.Translate(Vector2.down * (speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Translate(new Vector2(-1, 0));
            transform.Translate(Vector2.left * (speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.Translate(new Vector2(1, 0));
            transform.Translate(Vector2.right * (speed * Time.deltaTime));
        }*/
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnPlayerHealthChanged?.Invoke(currentHealth/100f);
        UIWeaponUpgrade.Instance.OnWeaponLost();
        ProjectilePool.Instance.CanUseSuperShoot = false;
        if (currentHealth <= 0)
        {
            // TODO: change this logic
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Debug.Log("Player Murio");
            gameObject.SetActive(false);
            _uiWeaponUpgrade.OnWeaponLost();
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class WeaponUpgradeItem : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool canUse;
    public ObjectPool<WeaponUpgradeItem> ItemPool { get; set; } //struct getter setter
    void Update()
    {
        transform.Translate(transform.right * (-1 * (speed * Time.deltaTime)));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            ItemPool.Release(this);
            ProjectilePool.Instance.CanUseSuperShoot = true;
            UIWeaponUpgrade.Instance.OnWeaponEquipped();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class WeaponUpgradeItemPool : MonoBehaviour
{
    public static WeaponUpgradeItemPool Instance { get; private set; }
    private ObjectPool<WeaponUpgradeItem> _weaponItemPool;
    [SerializeField] private WeaponUpgradeItem itemPrefab;
    [SerializeField] private Transform spawnPoint;
    
    private void Awake()
    {
        Instance = this;
        _weaponItemPool = new ObjectPool<WeaponUpgradeItem>(CreateWeaponItemPool, GetWeaponItemPool, ReleaseWeaponItemPool);
    }

    private WeaponUpgradeItem CreateWeaponItemPool()
    {
        var itemCopy = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        itemCopy.ItemPool = _weaponItemPool;
        return itemCopy;
    }

    private void GetWeaponItemPool(WeaponUpgradeItem item)
    {
        var randomPositionY = Random.Range(-4, 4);
        item.transform.position = spawnPoint.position + new Vector3(0, randomPositionY, 0);
        item.gameObject.SetActive(true);
    }

    private void ReleaseWeaponItemPool(WeaponUpgradeItem item)
    {
        item.gameObject.SetActive(false);
    }

    public void SpawnItem()
    {
        _weaponItemPool.Get();
    }
}

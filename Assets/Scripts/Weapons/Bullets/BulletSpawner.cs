﻿using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private Dictionary<BulletType, BulletMain> bulletManager = new Dictionary<BulletType, BulletMain>();

    private void OnEnable()
    {
        ServiceLocator.Subscribe<BulletSpawner>(this);
    }

    private void OnDisable()
    {
        ServiceLocator.UnSubscribe<BulletSpawner>();
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        bulletManager.Add(BulletType.SingleShot, new SingleShot());
        bulletManager.Add(BulletType.ShotGunShot, new ShotGunShot());
        bulletManager.Add(BulletType.HandWeaponHit, new HandWeaponHit());
    }

    public void SpawnBullet(Transform startPosition, BulletType bulletType, int damage)
    {
        bulletManager[bulletType].Shot(startPosition.transform, damage);
    }
}
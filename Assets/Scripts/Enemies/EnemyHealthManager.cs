using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    public delegate void HealthDelegate(float p);
    public event HealthDelegate onHealthUpdated;

    protected override void HealthUpdate()
    {
        onHealthUpdated?.Invoke(currentHealth);
    }

    protected override void Die()
    {
        this.gameObject.SetActive(false);
    }
}

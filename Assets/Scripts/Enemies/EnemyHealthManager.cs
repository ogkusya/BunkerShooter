using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    protected override void Die()
    {
        this.gameObject.SetActive(false);
    }
}

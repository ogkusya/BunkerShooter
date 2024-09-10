using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamageable
{
    [SerializeField] protected int maxHealth;
    protected int currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage, DamageableType damageableType)
    {
        currentHealth -= damage;
        HealthUpdate();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void HealthUpdate() { }

    protected virtual void Die() { }
}

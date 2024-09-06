using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private PlayerHealthManager _target;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerHealthManager>();
    }

    public void Hit()
    {
        _target.TakeDamage(damage, DamageableType.Enemy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWeaponHit : BulletMain
{
    public override void Shot(Transform startPosition, int damage)
    {
        if (Physics.Raycast(startPosition.position, startPosition.forward, out var hit, 2f))
        {
            var decalListener = hit.transform.GetComponent<DecalListener>();
            var damageable = hit.transform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            var rigidbody = hit.transform.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddForce(hit.normal * -155);
            }
        }
    }
}

using System;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationController
{
    private readonly Animator _animator;

    private Dictionary<WeaponAnimationType, int> weaponAnimationTypeHash = new Dictionary<WeaponAnimationType, int>();

    public Animator Animator => _animator;

    public WeaponAnimationController(Animator animator)
    {
        _animator = animator;
        foreach (WeaponAnimationType weaponAnimationType in Enum.GetValues(typeof(WeaponAnimationType)))
        {
            weaponAnimationTypeHash.Add(weaponAnimationType, Animator.StringToHash(weaponAnimationType.ToString()));
        }
    }

    public void SetBool(WeaponAnimationType weaponAnimationType, bool value)
    {
        _animator.SetBool(weaponAnimationTypeHash[weaponAnimationType], value);
    }

    public void SetTrigger(WeaponAnimationType weaponAnimationType)
    {
        _animator.SetTrigger(weaponAnimationTypeHash[weaponAnimationType]);
    }
}
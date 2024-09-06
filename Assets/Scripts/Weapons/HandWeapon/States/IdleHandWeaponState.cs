using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleHandWeaponState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public IdleHandWeaponState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.HandWeaponIdle, true);
    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.HandWeaponIdle, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolIdleState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolIdleState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolIdle, true);
    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolIdle, false);
    }
}

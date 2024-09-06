using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Profiling;

[RequireComponent(typeof(Animator))]
public class HandWeaponStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;
    private StateMachine _hitMachine;

    // private bool isReadyToHit => CheckReadyHit();

    private void Awake()
    {
        InitializedStateMachine();
    }
    private void Update()
    {
        _stateMachine.OnUpdate();
        _hitMachine.OnUpdate();
    }
    private void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
        _hitMachine.OnFixedUpdate();
    }
    private void InitializedStateMachine()
    {
        var animatorController = new WeaponAnimationController(GetComponent<Animator>());
        var idleState = new IdleHandWeaponState(animatorController);
        var showState = new ShowHandWeaponState(animatorController);
        var runState = new RunHandWeaponState(animatorController);


        /* showState.AddTransition(new StateTransition(idleState,
             new AnimationTransitionCondition(animatorController.Animator, WeaponAnimationType.HandWeaponShow.ToString())));*/
        showState.AddTransition(new StateTransition(idleState,
             new TemporaryCondition(1f)));

        idleState.AddTransition(new StateTransition(runState,
            new FuncStateCondition(() => InputManager.IsSprint)));

        runState.AddTransition(new StateTransition(idleState,
            new FuncStateCondition(() => !InputManager.IsSprint)));

        _stateMachine = new StateMachine(showState);
        InitializeHitStateMachine(animatorController);

    }
    private void InitializeHitStateMachine(WeaponAnimationController weaponAnimationController)
    {
        var idleState = new IdleHandWeaponState(weaponAnimationController);
        var hitState = new HitHandWeaponState(weaponAnimationController);

        idleState.AddTransition(new StateTransition(hitState,
            new FuncStateCondition(() => InputManager.IsAttack)));

        // hitState.AddTransition(new StateTransition(idleState, new AnimationTransitionCondition(weaponAnimationController.Animator, WeaponAnimationType.HandWeaponHit.ToString())));
        hitState.AddTransition(new StateTransition(idleState, new TemporaryCondition(1f)));

        _hitMachine = new StateMachine(idleState);
    }
}

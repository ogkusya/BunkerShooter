using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController
{
    private readonly Animator _animator;

    private Dictionary<EnemyAnimationType, int> enemyAnimationTypeHash = new Dictionary<EnemyAnimationType, int>();

    public Animator Animator => _animator;

    public EnemyAnimationController(Animator animator)
    {
        _animator = animator;
        foreach (EnemyAnimationType enemyAnimationType in Enum.GetValues(typeof(EnemyAnimationType)))
        {
            enemyAnimationTypeHash.Add(enemyAnimationType, Animator.StringToHash(enemyAnimationType.ToString()));
        }
    }

    public void SetBool(EnemyAnimationType enemyAnimationType, bool value)
    {
        _animator.SetBool(enemyAnimationTypeHash[enemyAnimationType], value);
    }

    public void SetTrigger(EnemyAnimationType enemyAnimationType)
    {
        _animator.SetTrigger(enemyAnimationTypeHash[enemyAnimationType]);
    }
}

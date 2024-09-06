using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaHitRandom : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("IdHit", Random.Range(0, 3));
    }
}


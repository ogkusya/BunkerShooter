using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStateMachine : MonoPooled
{
    [SerializeField] private float distToAttackPlayer = 1.3f;
    [SerializeField] private string currentState;

    private Transform _target;
    private bool _isNearPlayer;

    private StateMachine _stateMachine;
    private NavMeshAgent _navMeshAgent;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distToAttackPlayer);
    }
#endif

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindObjectOfType<PlayerController>().transform;
        InitializeStateMachine();
    }

    public override void Initialize()
    {
        base.Initialize();
        //InitializeStateMachine();
    }

    private void Update()
    {
        _stateMachine?.OnUpdate();
        currentState = _stateMachine.CurrentState.ToString();

        _isNearPlayer = Vector3.Distance(_navMeshAgent.transform.position, _target.position) < distToAttackPlayer;
    }

    private void FixedUpdate()
    {
        _stateMachine?.OnFixedUpdate();
    }

    private void InitializeStateMachine()
    {
        EnemyAnimationController characterNPCAnimatorController = new EnemyAnimationController(GetComponent<Animator>());

        EnemyRunState runState = new EnemyRunState(characterNPCAnimatorController, _navMeshAgent, _target);
        EnemyAttackState attackState = new EnemyAttackState(characterNPCAnimatorController, _target, transform);

        runState.AddTransition(new StateTransition(attackState, new FuncStateCondition(() => _isNearPlayer )));
        attackState.AddTransition(new StateTransition(runState, new FuncStateCondition(() => !_isNearPlayer )));

        _stateMachine = new StateMachine(runState);
    }
}

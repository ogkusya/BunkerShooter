using UnityEngine;
using UnityEngine.AI;

public class EnemyRunState : State
{
    private EnemyAnimationController _controller;
    private NavMeshAgent _navMeshAgent;
    private Transform _target;

    public EnemyRunState(EnemyAnimationController controller, NavMeshAgent agent, Transform target)
    {
        _controller = controller;
        _navMeshAgent = agent;
        _target = target;
    }

    public override void OnStateEntered()
    {
        _navMeshAgent.enabled = true;
        _controller.SetBool(EnemyAnimationType.RunBool, true);
    }

    public override void OnStateExited()
    {
        _navMeshAgent.enabled = false;
        _controller.SetBool(EnemyAnimationType.RunBool, false);
    }

    public override void OnUpdate(float deltaTime)
    {
        _navMeshAgent.SetDestination(_target.position);
    }
}

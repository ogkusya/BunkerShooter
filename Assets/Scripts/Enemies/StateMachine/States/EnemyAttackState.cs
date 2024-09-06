using UnityEngine;

public class EnemyAttackState : State
{
    private readonly EnemyAnimationController _controller;
    private readonly Transform _target;
    private readonly Transform _enemyTransform;

    public EnemyAttackState(EnemyAnimationController controller, Transform target, Transform enemyTransform)
    {
        _controller = controller;
        _target = target;
        _enemyTransform = enemyTransform;
    }

    public override void OnStateEntered()
    {
        _controller.SetBool(EnemyAnimationType.AttackBool, true);
    }

    public override void OnStateExited()
    {
        _controller.SetBool(EnemyAnimationType.AttackBool, false);
    }

    public override void OnUpdate(float deltaTime)
    {
        Vector3 lookDirection = (_target.position - _enemyTransform.position).normalized;
        lookDirection.y = 0;
        _enemyTransform.rotation = Quaternion.LookRotation(lookDirection);
    }
}

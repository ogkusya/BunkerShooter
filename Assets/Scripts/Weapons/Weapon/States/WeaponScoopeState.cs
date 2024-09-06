public class WeaponScoopeState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public WeaponScoopeState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.Scope, true);
    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.Scope, false);
    }
}
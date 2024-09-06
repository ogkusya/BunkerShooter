public class PistolScopeState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolScopeState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolScope, true);
    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolScope, false);
    }
}

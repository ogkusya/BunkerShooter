public class ReloadWeaponState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public ReloadWeaponState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetTrigger(WeaponAnimationType.Reload);
    }
}
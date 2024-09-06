public class ShowWeaponState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public ShowWeaponState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.Show, true);
    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.Show, false);
    }
}
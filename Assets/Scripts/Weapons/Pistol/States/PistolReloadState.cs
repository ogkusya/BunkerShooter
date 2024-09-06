public class PistolReloadState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolReloadState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetTrigger(WeaponAnimationType.PistolReload);
        _weaponAnimationController.SetBool(WeaponAnimationType.IsReloadPistol, true);

    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.IsReloadPistol, false);
    }
}

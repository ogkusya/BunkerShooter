public class PistolRunState: State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolRunState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolRun, true);
    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolRun, false);
    }
}

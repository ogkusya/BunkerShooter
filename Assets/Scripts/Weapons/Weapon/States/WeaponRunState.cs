public class WeaponRunState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public WeaponRunState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.Run, true);
    }

    public override void OnStateExited()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.Run, false);
    }
}
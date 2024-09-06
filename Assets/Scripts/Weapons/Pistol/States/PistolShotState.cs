public class PistolShotState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolShotState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEntered()
    {
        _weaponAnimationController.SetTrigger(WeaponAnimationType.PistolShot);
    }
    
}
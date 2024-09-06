using UnityEngine;

public class PistolShowState: State
{
    private WeaponAnimationController _controller;

    public PistolShowState(WeaponAnimationController controller)
    {
        _controller = controller;
    }
    public override void OnStateEntered()
    {
        Debug.Log("ENTER");
        _controller.SetBool(WeaponAnimationType.PistolShow, true);
       // _controller.Animator.SetBool(WeaponAnimationType.PistolShow.ToString(), true);
    }
    public override void OnStateExited()
    {
        Debug.Log("EXIT");
        _controller.SetBool(WeaponAnimationType.PistolShow, false);
        //_controller.Animator.SetBool(WeaponAnimationType.PistolShow.ToString(), false);
    }
}

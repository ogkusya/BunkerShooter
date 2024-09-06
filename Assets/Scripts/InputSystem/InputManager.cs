using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset playerActions;

    private static InputActionMap playerActionMap;
    private static InputAction moveAction;
    private static InputAction lookAction;
    private static InputAction sprintAction;
    private static InputAction jumpAction;
    private static InputAction attackAction;
    private static InputAction aimAction;
    private static InputAction reloadWeaponAction;
    private static InputAction chooseWeapon1Action;
    private static InputAction chooseWeapon2Action;

    public static Vector2 moveInput;
    public static Vector2 lookInput;

    public static bool IsMove { get; private set; }
    public static bool IsSprint { get; private set; }
    public static bool IsJump { get; private set; }
    public static bool IsCrouch { get; private set; }
    public static bool IsAttack { get; private set; }
    public static bool IsAim { get; private set; }
    public static bool IsReloadWeapon { get; private set; }
    public static bool IsChooseWeapon1 { get; private set; }
    public static bool IsChooseWeapon2 { get; private set; }

    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        sprintAction.Enable();
        jumpAction.Enable();
        attackAction.Enable();
        aimAction.Enable();
        reloadWeaponAction.Enable();
        chooseWeapon1Action.Enable();
        chooseWeapon2Action.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        sprintAction.Disable();
        jumpAction.Disable();
        attackAction.Disable();
        aimAction.Disable();
        reloadWeaponAction.Disable();
        chooseWeapon1Action.Disable();
        chooseWeapon2Action.Disable();
    }

    private void Awake()
    {
        moveAction = playerActions.FindActionMap("Player").FindAction("Move");
        moveAction.performed += context => moveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => moveInput = Vector2.zero;

        lookAction = playerActions.FindActionMap("Player").FindAction("Look");
        lookAction.performed += context => lookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => lookInput = Vector2.zero;

        sprintAction = playerActions.FindActionMap("Player").FindAction("Sprint");
        jumpAction = playerActions.FindActionMap("Player").FindAction("Jump");

        attackAction = playerActions.FindActionMap("Player").FindAction("Attack");

        aimAction = playerActions.FindActionMap("Player").FindAction("Aim");
        reloadWeaponAction = playerActions.FindActionMap("Player").FindAction("ReloadWeapon");

        chooseWeapon1Action = playerActions.FindActionMap("Player").FindAction("ChooseWeapon1");
        chooseWeapon2Action = playerActions.FindActionMap("Player").FindAction("ChooseWeapon2");

    }

    void Update()
    {
        IsMove = moveInput.y != 0 || moveInput.x != 0;
        IsSprint = sprintAction.ReadValue<float>() > 0;
        IsJump = jumpAction.triggered;
        IsAttack = attackAction.IsPressed();
        IsAim = aimAction.IsPressed();
        IsReloadWeapon = reloadWeaponAction.triggered;
        IsChooseWeapon1 = chooseWeapon1Action.triggered;
        IsChooseWeapon2 = chooseWeapon2Action.triggered;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Camera Look Parameters")]
    [SerializeField] private float mouseSensitivity = 2.0f;
    [SerializeField] private float upDownRange = 80.0f;

    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] float gravity = 9.81f;

    [Header("Crouch Parameters")]
    //[SerializeField] float crouchColliderHeight = 1.35f;

    private CharacterController _characterController;
    private Camera _playerCamera;
    private Vector3 _currentMoveDirection = Vector3.zero;
    private float _rotationX = 0f;
    private bool _isMoving = false;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerCamera = Camera.main;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    

    void Update()
    {
        PlayerMovement();
        CameraLook();
    }

    private void PlayerMovement()
    {
        float speedMultiplier = InputManager.IsSprint ? sprintMultiplier : 1f;

        float inputX = InputManager.moveInput.x * walkSpeed * speedMultiplier;
        float inputZ = InputManager.moveInput.y * walkSpeed * speedMultiplier;

        Vector3 horizontalMovement = new Vector3(inputX, 0f, inputZ);
        horizontalMovement = transform.rotation * horizontalMovement;

        PlayerGravityAndJumping();

        _currentMoveDirection.x = horizontalMovement.x;
        _currentMoveDirection.z = horizontalMovement.z;

        _characterController.Move(_currentMoveDirection * Time.deltaTime);

        _isMoving = InputManager.IsMove;
    }

    private void PlayerGravityAndJumping()
    {
        if (_characterController.isGrounded)
        {
            _currentMoveDirection.y = -0.5f;

            if (InputManager.IsJump)
            {
                _currentMoveDirection.y = jumpForce;
            }
        }
        else
        {
            _currentMoveDirection.y -= gravity * Time.deltaTime;
        }
    }

    private void CameraLook()
    {
        float mouseXRotation = InputManager.lookInput.x * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        _rotationX -= InputManager.lookInput.y * mouseSensitivity;
        _rotationX = Mathf.Clamp( _rotationX, -upDownRange, upDownRange);
        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }
}

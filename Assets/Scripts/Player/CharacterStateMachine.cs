using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStateMachine : MonoBehaviour
{
    //[Header("Movement Speeds")]
    //[SerializeField] private float walkSpeed = 3.0f;
    //[SerializeField] private float sprintMultiplier = 2.0f;

    //[Header("Jump Parameters")]
    //[SerializeField] private float jumpForce = 5.0f;
    //[SerializeField] float gravity = 9.81f;

    //[Header("Look Sensitivity")]
    //[SerializeField] private float mouseSensitivity = 2.0f;
    //[SerializeField] private float upDownRange = 80.0f;

    //[Header("Input Actions")]
    //[SerializeField] private InputManager inputManager;

    private StateMachine _stateMachine;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _stateMachine.OnUpdate();
    }

    private void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
    }

    private void InitializeStateMachine()
    {

    }
}

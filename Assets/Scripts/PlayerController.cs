using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float gravityMultiplier;

    [SerializeField]
    Transform groundCheck;

    CharacterController _characterController;

    float _inputX; //mueve al personaje en 3 dimensiones
    float _inputZ;

    float _gravityY;
    float _velocityY;

    bool _isJumpPressed;
    public bool _isGrounded;

    Camera _mainCamera;

    Vector3 _direction;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;

        _gravityY = Physics.gravity.y;
    }

    private void Start()
    {
        _isGrounded = IsGrounded();
        if (!_isGrounded)
        {
            StartCoroutine(WaitforGroundedCoroutine());
        }
    }

    private void Update()
    {
        HandleGravity();
        HandleMovement();

    }

    private void HandleGravity()
    {
        if (_isGrounded)
        {
            if (_velocityY < -1.0F)
            {
                _velocityY = -1.0F;
            }

            HandleJump();
            if (_isJumpPressed)
            {
                Jump();
            }
        }
        else
        {
            _velocityY += _gravityY * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");
    }

    private void HandleJump()
    {
        _isJumpPressed = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private bool IsMove()
    {
        return (_inputX != 0.0F || _inputZ != 0.0F);
    }

    private void Move()
    {
        _direction.y = _velocityY;
        _characterController.Move(_direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        if (!IsMove())
        {
            _direction = Vector3.zero;
            return;
        }

        _direction = Quaternion.Euler(0.0F, _mainCamera.transform.eulerAngles.y, 0.0F)
                     * new Vector3(_inputX, 0.0F, _inputZ);
        Quaternion targetRotation =  Quaternion.LookRotation(_direction, Vector3.up);
        
        transform.rotation = 
            Quaternion.RotateTowards (transform.rotation, targetRotation, rotationSpeed 
            * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        _velocityY = jumpForce;

        _isGrounded = false;
        StartCoroutine(WaitforGroundedCoroutine());
    }

    private bool IsGrounded()
    {
        //bool res = Physics.Raycast(groundCheck.position, Vector3.down, 0.65F);
        //return res;

        return _characterController.isGrounded;
    }

    private IEnumerator WaitforGroundedCoroutine()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(() => IsGrounded());
        _isGrounded = true;
    }
}
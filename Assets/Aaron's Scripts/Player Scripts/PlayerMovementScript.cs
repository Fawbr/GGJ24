using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Input Readings")]
    [SerializeField] InputReader input;
    public Vector2 RawMoveInput;

    [Header("Movment")]
    private CharacterController PlayerCC;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private float JumpHeight = 10;
    Rigidbody rb;
    //gravity
    private Vector3 velocity;
    public float gravity = -9.81f;

    [Header("Camera")]
    [SerializeField] Camera cam;
    [SerializeField] public MouseLook mouseLook = new MouseLook();
 
    [Header("Ground Check")]
    [SerializeField] Transform GroundPos;
    [SerializeField] float GroundCheckRadius = 0.3f;
    [SerializeField] private LayerMask WhatisGround;

    [Header("Player Stats")]
    [SerializeField]
    private int Health = 100;

    private IEnumerator coroutine;
    #region Unity Callbacks

    private void Start()
    {
        input.MoveEvent += HandleDirectionalInput;
        mouseLook.Init(transform, cam.transform,input);
        PlayerCC = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerRotation();
        PlayerMovement();
    }

    #endregion

    #region PlayerRotation

    void PlayerRotation()
    {
        // PlayerRotation is just a call of mouseLook.LookRotation
        mouseLook.LookRotation(transform, cam.transform);
    }

    #endregion

    #region Movement

    private void PlayerMovement()
    {
        if (IsGrounded() && velocity.y < 0)
        {
          velocity.y = -2f;
        }

        Vector3 moveDir = transform.forward * RawMoveInput.y + transform.right * RawMoveInput.x;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerCC.Move(moveDir * (moveSpeed*2) * Time.deltaTime);
        }
        else
        { 
            PlayerCC.Move(moveDir * (moveSpeed) * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;

        PlayerCC.Move(velocity * Time.deltaTime);
    }

    IEnumerator StartBounce(Vector3 bounceDir)
    {
        PlayerCC.enabled = false;
        rb.AddForce(bounceDir * 1000f, ForceMode.Force);
        yield return new WaitForSeconds(1f);
        PlayerCC.enabled = true;

    }
    #endregion

    #region Checks

    public bool IsGrounded()
    {

        if (Physics.CheckSphere(GroundPos.position, GroundCheckRadius, WhatisGround))
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Enemy Bat")
        {
            coroutine = StartBounce(other.transform.parent.transform.forward);
            StartCoroutine(coroutine);

        }
    }

    #endregion

    #region HandleEvents

    private void HandleDirectionalInput(Vector2 dir)
    {
        
        RawMoveInput = dir;
    }

    #endregion
}

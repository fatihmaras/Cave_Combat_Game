using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    //Movement
    private CharacterController controller;
    public float speed = 1f;

    //Camer Controller
    private float XRotation = 0f;
    public float MouseSensitivity = 100f;

    //Jump and Gravity
    private Vector3 Velocity;
    private float Gravity = -9.81f;
    private bool IsGround;

    public Transform GroundChecker;
    public float GroundCheckerRadius;
    public LayerMask ObstackleLayer;

    public float JumpHeight = 0.1f;
    public float GravityDivide = 100f;
    public float JumpSpeed=100;

    private float AcTimer;

    private void Awake()
    {
        controller=GetComponent<CharacterController>();

        //Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        //Check Characte is on ground
        IsGround = Physics.CheckSphere(GroundChecker.position, GroundCheckerRadius, ObstackleLayer);

        //Movement
        Vector3 MoveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 MoveVelocity = MoveInputs * Time.deltaTime * speed;

        controller.Move(MoveVelocity);

        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity, 0);
        XRotation-=Input.GetAxis("Mouse Y")*Time.deltaTime*MouseSensitivity;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(XRotation, 0, 0);


        
        //Jump and Gravity

        if (!IsGround)
        {
            Velocity.y += Gravity * Time.deltaTime / GravityDivide;
            AcTimer+=Time.deltaTime/3;
            speed = Mathf.Lerp(10,JumpSpeed,AcTimer);
            // silinmiþ controller.Move(Velocity);
        }
        else
        {
            Velocity.y = -0.05f;
            speed = 10;
            AcTimer=0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity / GravityDivide);
        }

      

        controller.Move(MoveVelocity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static scr_Model;

public class MovementPersonnage : MonoBehaviour
{
    private CharacterController characterController;
    private DefaultInput input;
    public Vector2 inputMovement;
    public Vector2 inputView;

    private Vector3 newCameraRotation;
    private Vector3 newPlayerRotation;

    [Header("References")]
    public Transform cameraHolder;

    [Header("Settings")]
    public PlayerSettingModel playerSettings;
    public float viewClampYMin = -70;
    public float viewClampYMax = 70;
    private bool playerJump;

    [Header("Gravity")]
    public float gravityAmount;
    public float playerGravity;
    public float gravityMin;

    public Vector3 jumpingForce;
    private Vector3 jumpingForceVelocity;
    



    private void Awake() 
    {
        input =  new DefaultInput();

        input.Character.Movement.performed += e => inputMovement = e.ReadValue<Vector2>();
        input.Character.View.performed += e => inputView = e.ReadValue<Vector2>();
        input.Character.View.performed += e => Jump();

        input.Enable();
        newCameraRotation = cameraHolder.localRotation.eulerAngles;
        newPlayerRotation = transform.localRotation.eulerAngles;

        characterController = GetComponent<CharacterController>();
    }


    private void Update() 
    {
        CalculateView();
        CalculateMovement();
        //CalculateJump();
    }

    private void Jump() 
    {
        if(!characterController.isGrounded) 
        {
            return;
        }
        // jump

        jumpingForce = Vector3.up * playerSettings.JumpingHeight;
    }


    private void CalculateView() 
    {
        newPlayerRotation.y += playerSettings.ViewXSensitivity * (playerSettings.ViewXInverted ? -inputView.x : inputView.x) * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(newPlayerRotation);


        newCameraRotation.x += playerSettings.ViewYSensitivity * (playerSettings.ViewYInverted ? inputView.y : -inputView.y) * Time.deltaTime;
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x,viewClampYMax,viewClampYMin);


        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);
    }

    private void CalculateMovement() 
    {
        var verticalSpeed = playerSettings.WalkingForwardSpeed * inputMovement.y * Time.deltaTime;
        var horizontalSpeed = playerSettings.WalkingStrafeSpeed * inputMovement.x * Time.deltaTime;
        var newMovementSpeed = new Vector3(horizontalSpeed,0,verticalSpeed);

        newMovementSpeed = transform.TransformDirection(newMovementSpeed);

        /*
        if (playerGravity > gravityMin && jumpingForce.y < 0.1f) 
        {
            playerGravity -= gravityAmount * Time.deltaTime;
        }

        if (playerGravity < -1 && characterController.isGrounded) 
        {
            playerGravity -=1;
        }

        if (jumpingForce.y > 0.1f) 
        {
            playerGravity = 0;
        }

        newMovementSpeed.y += playerGravity;
        newMovementSpeed += jumpingForce;
        */

        characterController.Move(newMovementSpeed);
    }




    private void CalculateJump() 
    {
       jumpingForce = Vector3.SmoothDamp(jumpingForce, Vector3.zero ,ref jumpingForceVelocity,playerSettings.JumpingFalloff);
    }

}

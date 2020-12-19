using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f; //gravity of earth
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f; //radius of sphere to check distance
    public LayerMask groundMask; //We want to control what objects the sphere checks for
    public float mouseSensitivity = 100f;
    //public Transform playerBody;

    float xRotation = 0f, yRotation = 0f;
    Vector3 velocity;
    bool isGrounded;

    public bool isSeated = false;

    public int currSeat = -1;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //This keeps cursor locked on the screen
    }

    void Update()
    {
        if (!isSeated)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            //to make sure player gets grounded with gravity
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; //makes sure our player is on the ground
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z; //This is a direction we want to move
            //based on our x and z movement
            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime; //we are adding gravity to our velocity
            controller.Move(velocity * Time.deltaTime); //adding the gravity to player
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            yRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //makes it so camera can't go past 90 degrees

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            //transform.Rotate(Vector3.up*mouseX); //this is allowing mouse to rotate side to side   
        }
    }
}

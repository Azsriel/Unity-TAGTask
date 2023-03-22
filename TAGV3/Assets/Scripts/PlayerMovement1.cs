using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    //References
    public CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundLayer;

    //Public variables
    public float speed = 12f;
    public float gravity = -19.6f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public int speedMultiplier = 5;
    public int numberOfJumps;

    //Bools
    bool isGrounded;

    //Other Declerations
    Vector3 velocity;


    //Update
    private void Update()
    {
        // If on ground, velocity from gravity resets
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
            numberOfJumps = 2;
        }

        //WASD Inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //Jump
        if (Input.GetButtonDown("Jump") && numberOfJumps > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            numberOfJumps--;
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= speedMultiplier;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= speedMultiplier;
        }

    }


}

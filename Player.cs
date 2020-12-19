using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;

    private Rigidbody rbody;
    private float moveSpeed;
    private bool onTrack;
    public float jumpStrength;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        moveSpeed = 5000f;
        jumpStrength = 3500f;
    }

    // Update is called once per frame
    void Update()
    {
        float walkInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Vertical");

        if (onTrack)
        {
            if (jumpInput > 0f)
            {
                jump();
            }

            //Walking right
            if (walkInput < 0f)
            {
                playerAnim.SetBool("Walking", true);
                transform.rotation = Quaternion.Euler(0f, walkInput * -90f, 0f);
                rbody.AddForce(moveSpeed * walkInput * Time.deltaTime, 0f, 0f);
            }
            //walking left
            else if (walkInput > 0f)
            {
                playerAnim.SetBool("Walking", true);
                transform.rotation = Quaternion.Euler(0f, walkInput * -90f, 0f);
                rbody.AddForce(moveSpeed * walkInput * Time.deltaTime, 0f, 0f);
            }
            else
            {
                playerAnim.SetBool("Walking", false);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 10f * Time.deltaTime);
            }
        }
    }

    void jump()
    {
        onTrack = false;
        rbody.AddForce(0f, jumpStrength, 0f);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            rbody.drag = 5f;
            onTrack = true;
        }
    }
}
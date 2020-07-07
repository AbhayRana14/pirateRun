using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{


    private float speed = 40f, maxVelocity = 8f;
    private Rigidbody2D rb;
    private Animator anim;

    private bool isGrounded = false;
    private float jumpForce=500f;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
     void FixedUpdate()
    {
        PlayerWalkKeyboard();
        Jump();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerWalkKeyboard() {
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
            
            anim.SetBool("Walk", true);

        }



        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = -  1f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else {
            anim.SetBool("Walk", false);

        }

        rb.AddForce(new Vector2(forceX,0));

        

    }

    private void Jump()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                isGrounded = false;
                rb.AddForce(new Vector2(0, jumpForce));
            } 
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Ground")
        {
            isGrounded = true;  
        }
    }
}




























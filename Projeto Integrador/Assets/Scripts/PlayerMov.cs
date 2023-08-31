using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    //Run
    public float spd = 1;

    float hspd;
    float vspd;
    Animator animator;
    bool facingRight;

    //Jump
    public float jumpForce = 300;
    Rigidbody2D rigidbody1;
    float axisY;
    bool isJumping;

    //Atack
    public bool isAtacking = false;



    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody1 = GetComponent<Rigidbody2D>();
        rigidbody1.Sleep();
    }

    void Update()
    {
        hspd = Input.GetAxis("Horizontal");
        vspd = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(hspd * spd, vspd * spd, 0.0f);
        transform.position = transform.position + mov * Time.deltaTime;
        Flip(hspd);

        animator.SetFloat("Speed", Mathf.Abs(hspd != 0 ? hspd : vspd));

        if (Input.GetButtonDown("Fire1"))
        {
            isAtacking = true;
            if(vspd != 0 || hspd !=0)
            {
                spd = 0;
                animator.SetFloat("Speed", 0);
            }

            animator.SetTrigger("Atack");
            spd = 3;
        }


        if (transform.position.y <= axisY && isJumping)
        {
            OnLanding();
        }

        if (Input.GetButton("Jump") && !isJumping)
        {
            axisY = transform.position.y;
            isJumping = true;
            rigidbody1.gravityScale = 1.5f;
            rigidbody1.WakeUp();
            rigidbody1.AddForce(new Vector2(transform.position.x + 7.5f, jumpForce));
            animator.SetBool("isJumping", isJumping);
        }


    }


    public void AlertObservers(string message)
    {
        if(message == "AtackEnded")
        {
            isAtacking = false;
        }
    }


    void Flip(float hspd)
    {
        if (hspd < 0 && !facingRight || hspd > 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    void OnLanding()
    {
        isJumping = false;
        rigidbody1.gravityScale = 0f;
        rigidbody1.Sleep();
        axisY = transform.position.y;
        animator.SetBool("isJumping", false);
    }

}

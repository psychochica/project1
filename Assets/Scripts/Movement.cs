using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    SpriteRenderer sr;
    Animator anim;

    public float upForce = 100;
    public float speed = 1500;
    public float runSpeed = 2500;

    public bool isGrounded = false;
    bool isLeftShift;
    float moveHorizontal;
    float moveVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
       
    }
    // Update is called once per frame
    void Update()
    {
       isLeftShift = Input.GetKey(KeyCode.LeftShift);
       moveHorizontal = Input.GetAxis("Horizontal");
       moveVertical = Input.GetAxis("Vertical");

       if (moveHorizontal>0)
       {
        sr.flipX = false;
       }
       else if (moveHorizontal<0)
       {
         sr.flipX = true;
       }

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            anim.SetBool("isRunning",false);
        }
        else
        {
            anim.SetBool("isRunning",true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * upForce);
            isGrounded = false;
            anim.SetBool("isJumping",true);
        }

    }

    private void FixedUpdate()
    {
         if (isLeftShift)
        {
            rb.velocity = new Vector3(moveHorizontal * runSpeed * Time.deltaTime, rb.velocity.y, moveVertical * runSpeed * Time.deltaTime);
        }
        else 
        {
            rb.velocity = new Vector3(moveHorizontal * speed * Time.deltaTime, rb.velocity.y, moveVertical * speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        anim.SetBool("isJumping",false);
    }

    public void Save()
    {
        SaveData.instance.playerX = transform.position.x;
        SaveData.instance.playerY = transform.position.y;
        SaveData.instance.playerZ = transform.position.z;
    }
}
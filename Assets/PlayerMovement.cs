using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 3.0f;
    public float jumpSpeed = 7.0f;
    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, jumpSpeed);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = moveSpeed;
            GetComponent<Animator>().SetBool("running", true);
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -moveSpeed;
            GetComponent<Animator>().SetBool("running", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<Animator>().SetBool("running", false);
            movement.x = 0;
        }


        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            movement.y = jumpSpeed;
            GetComponent<Animator>().SetBool("jumping", true);

        }
        rb.velocity = movement;    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("jumping", false);
    }
}

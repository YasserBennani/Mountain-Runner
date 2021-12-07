using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    int groundMask = 1 << 8; // this is a “bitshift”
    bool isIdle;
    bool isLeft;
    int isIdleKey = Animator.StringToHash("isIdle");
    int canJumpKey = Animator.StringToHash("canJump");
    int isDeadKey = Animator.StringToHash("isDead");
    public float jumpForce = 10f;
    public float runSpeed = 8f;
    public bool isDead = false;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(runSpeed, rb.velocity.y);


        Animator a = GetComponent<Animator>();
        a.SetBool(isIdleKey, isIdle);
        a.SetBool(canJumpKey, canJump);
        a.SetBool(isDeadKey, isIdle);
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.flipX = isLeft;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        isIdle = false;
        // the new velocity to apply to the character
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        physicsVelocity.x += runSpeed;
        // move to the left
        if (Input.GetKey(KeyCode.A))
        {
            isIdle = false;
            isLeft = true;
            physicsVelocity.x -= runSpeed;
        }
        // implement moving to the right for the D key
        // move to the right
        if (Input.GetKey(KeyCode.D))
        {
            isIdle = false;
            isLeft = false;
            physicsVelocity.x += runSpeed;
        }
        // this allows the player to jump, but only if canJump is true
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (canJump)
            {
                // we're setting the absolute velocity here
                // but we still want to carry on moving left
                // or right. So include the current horizontal
                // velocity
                r.velocity = new Vector2(physicsVelocity.x, jumpForce);
                canJump = false;
            }
        }
        // Test the ground immediately below the Player
        // and if it tagged as a Ground layer, then we allow the
        // Player to jump again. The capsule collider is 4.8 units
        // high, so 2.5 units “down” from its centre will be just
        // touching the floor when we are on the ground.
        if (Physics2D.Raycast(new Vector2
        (transform.position.x,
        transform.position.y),
        -Vector2.up, 2.5f, groundMask))
        {
            canJump = true;
        }
        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(physicsVelocity.x,
        r.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("DEBUG");
        if (col.gameObject.tag == "BG")
        {
            Debug.Log("Collision with BG collider");
            isDead = true;
        }
    }
}

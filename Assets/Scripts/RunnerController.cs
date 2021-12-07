using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    int groundMask = 1 << 8; // this is a “bitshift”
    public bool canJump = true;
    public bool isDead = false;
    public bool isBoosted = false;
    public bool isShielded = false;
    bool isIdle;
    int isIdleKey = Animator.StringToHash("isIdle");
    int canJumpKey = Animator.StringToHash("canJump");
    int isDeadKey = Animator.StringToHash("isDead");
    public float jumpForce = 80f;
    public float runSpeed = 25f;
    public Rigidbody2D rb;
    public float jumpPotionDuration;
    public float ShieldInvulnerabilityDuration;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Animator a = GetComponent<Animator>();
        a.SetBool(isIdleKey, isIdle);
        a.SetBool(canJumpKey, canJump);
        a.SetBool(isDeadKey, isDead);
        SpriteRenderer r = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        isIdle = false;
        // the new velocity to apply to the character
        Vector2 physicsVelocity = Vector2.zero;
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        physicsVelocity.x += runSpeed;

        // this allows the player to jump, but only if canJump is true
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (canJump)
            {
                r.velocity = new Vector2(physicsVelocity.x, jumpForce);
                canJump = false;
            }
        }
        // Test the ground immediately below the Player
        // and if it tagged as a Ground layer, then we allow the
        // Player to jump again. The capsule collider is 0.38 units
        // high, so 0.2 (2.6 don't know why) units “down” from its centre will be just
        // touching the floor when we are on the ground.
        if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y)
            , -Vector2.up, 2.6f, groundMask))
        {
            canJump = true;
        }
        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(physicsVelocity.x, r.velocity.y);


        // if player is dead stop movement
        if (isDead)
        {
            r.velocity = Vector2.zero;
        }
    }
}

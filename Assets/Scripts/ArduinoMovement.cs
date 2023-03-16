using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ArduinoMovement : MonoBehaviour
{
    public static ArduinoMovement Instance;

    [HideInInspector] public Rigidbody2D rb;
    public float sensitivity = 0.01f;

    public float jumpHeight = 6.5f;

    bool isGrounded = false;
    CapsuleCollider2D mainCollider;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; 
    }

    // Update is called once per frame
    void Update()
    {
        LimitSpeed();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    public void MovePlayer(float data)
    {
        rb.AddForce(transform.right * data * sensitivity * Time.deltaTime, ForceMode2D.Force);
        //rb.velocity = new Vector2(data * sensitivity * Time.deltaTime, rb.velocity.y);
    }

    private void GroundCheck()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    public void Jump()
    {
        if (isGrounded)
            Invoke(nameof(JumpForce), 0.1f);
    }

    private void JumpForce()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    public void LimitSpeed()
    {

        Vector2 flatVel = new Vector2(rb.velocity.x, rb.velocity.y);

        // Limit velocity if needed


        if (flatVel.magnitude > sensitivity)
        {
            Vector2 limitedVel = flatVel.normalized * sensitivity;
            rb.velocity = new Vector2(limitedVel.x, rb.velocity.y);
        }


    }
}

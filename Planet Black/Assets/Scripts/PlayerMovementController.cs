using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField, Tooltip("How fast will the player accelerate?")]
    private float m_accelerationRate;
    
    [SerializeField, Tooltip("The fastest the player will walk.")]
    private float m_maxWalkSpeed;

    [SerializeField, Tooltip("The fastest the player will climb ladders.")]
    private float m_maxClimbingSpeed;

    private float m_horizontalInput, m_verticalInput;

    private bool m_isGrounded;

    private Rigidbody2D m_playerRigidbody;

    private SpriteRenderer m_playerRenderer;

    private Animator m_animator = null;

    // Start is called before the first frame update
    void Awake()
    {
        m_playerRigidbody = GetComponent<Rigidbody2D>();
        m_playerRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
        m_verticalInput = Input.GetAxisRaw("Vertical");

        SetDefaultValues();
    }

    private void SetDefaultValues()
    {
        if (m_accelerationRate == 0.0f)
        {
            m_accelerationRate = 10.0f;
        }

        if (m_maxWalkSpeed == 0.0f)
        {
            m_maxWalkSpeed = 10.0f;
        }

        if (m_maxClimbingSpeed == 0.0f)
        {
            m_maxClimbingSpeed = 10.0f;
        }
    }

    private void FixedUpdate()
    {
        HorizontalMovementHandler();
    }

    /// <summary>
    /// Acts on the movement input recieved from the player
    /// </summary>
    private void HorizontalMovementHandler()
    {
        if (!Mathf.Approximately(m_horizontalInput, 0.0f))
        {
            // Display player's walking animation 
            m_animator.SetBool("HubbleIsWalking", true);

            m_playerRigidbody.AddForce(Vector2.right * m_horizontalInput * (m_maxWalkSpeed * m_accelerationRate));

            Vector2 clampedVelocity = m_playerRigidbody.velocity;

            clampedVelocity.x = Mathf.Clamp(m_playerRigidbody.velocity.x, -m_maxWalkSpeed, m_maxWalkSpeed);

            m_playerRigidbody.velocity = clampedVelocity;

            // Flip sprite if the player is moving left
            if (m_horizontalInput < -0.1f)
            {
                m_playerRenderer.flipX = true;
            }
            else
            {
                m_playerRenderer.flipX = false;
            }
        }
        else if (Mathf.Approximately(m_horizontalInput, 0.0f))
        {
            // Stop displaying player's walking animation
            m_animator.SetBool("HubbleIsWalking", false);

            Vector2 stoppingVelocity = m_playerRigidbody.velocity;

            if (m_isGrounded)
            {
                stoppingVelocity = new Vector2(0.0f, 0.0f);
            }
            else
            {
                stoppingVelocity.x = 0.0f;  
            }
            m_playerRigidbody.velocity = stoppingVelocity;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            //TODO: Debug: Check for Ladder collision trigger
            Debug.Log("The player has detected the ladder");

            if (!Mathf.Approximately(m_verticalInput, 0.0f))
            {
                m_playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

                m_playerRigidbody.AddForce(Vector2.up * m_verticalInput * (m_maxClimbingSpeed * m_accelerationRate));

                Vector2 clampedVelocity = m_playerRigidbody.velocity;

                clampedVelocity.y = Mathf.Clamp(m_playerRigidbody.velocity.y, -m_maxClimbingSpeed, m_maxClimbingSpeed);

                m_playerRigidbody.velocity = clampedVelocity;
            }
            else
            {
                m_playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            m_playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isGrounded = false;
        }
    }
}

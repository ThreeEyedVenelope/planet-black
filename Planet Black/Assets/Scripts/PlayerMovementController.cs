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

    private float m_horizontalInput;

    private Rigidbody2D m_playerRigidbody;

    private SpriteRenderer m_playerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_playerRigidbody = GetComponent<Rigidbody2D>();
        m_playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(m_horizontalInput, 0.0f))
        {
            m_playerRigidbody.AddForce(Vector2.right * m_horizontalInput * m_accelerationRate);

            Vector2 clampedVelocity = m_playerRigidbody.velocity;

            clampedVelocity.x = Mathf.Clamp(m_playerRigidbody.velocity.x, -m_maxWalkSpeed, m_maxWalkSpeed);

            //TODO: Edit this to apply the climbing mechanic
            clampedVelocity.y = 0.0f;

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
        else
        {
            Vector2 stoppingVelocity = m_playerRigidbody.velocity;

            stoppingVelocity = new Vector2(0.0f, 0.0f);

            m_playerRigidbody.velocity = stoppingVelocity;
        }
    }
}

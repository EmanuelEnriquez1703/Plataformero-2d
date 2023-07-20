using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoPlayer : MonoBehaviour
{
    public float jumpForce = 5f;
    public float doubleJumpForce = 4f;
    private bool isJumping = false;
    private bool isDoubleJumping = false;
    private Rigidbody2D rb;
    public PauseManager pauseManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(pauseManager.enPausa == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isJumping = true;
            }
            else if (!isDoubleJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                isDoubleJumping = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isDoubleJumping = false;
        }
    }
}


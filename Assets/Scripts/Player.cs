using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private float horizontalInput;
    public float jumpForce;
    public Foot foot;

    public int score;
    public Text scoreText;

    public GameObject deathPanel;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (horizontalInput == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
        
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (foot.isOnGround)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            score += 1;
            scoreText.text = "Score: " + score;
        }

        if (collision.gameObject.tag == "Trap")
        {
            //Destroy(gameObject);
            Time.timeScale = 0;
            deathPanel.SetActive(true);
            
        }
    }
}

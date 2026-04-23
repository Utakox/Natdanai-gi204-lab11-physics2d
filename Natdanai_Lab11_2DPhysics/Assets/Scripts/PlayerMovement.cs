using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
    

{

    public float speed;
    private float move;

    public float jumpForce;

    private bool isGrounded = false;

    Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
       
        
            move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce), ForceMode2D.Impulse);
        }
    
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    } 

}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;
    public Animator Anim;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    public bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            checkRadius,
            groundLayer
        );

        if(isGrounded &&(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            //rb.linearVelocityY = jumpSpeed;
            rb.AddForceY(jumpSpeed * 50f);
            Anim.SetTrigger("takeoff");
        }

        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space)) && rb.linearVelocityY > 0f)
        {
            rb.linearVelocityY *= 0.67f;
        }

        if(rb.linearVelocityY < 0f)
        {
            rb.gravityScale = 10f;
        }
        else
        {
            rb.gravityScale = 2f;
        }

        if (isGrounded)
        {
            rb.linearDamping = 3f;
        }
        else
        {
            rb.linearDamping = 0f;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rb.linearVelocityX = 0f;
        }

        Anim.SetBool("isJumping", !isGrounded);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocityX = speed;
            transform.localScale = new Vector2(1, transform.localScale.y);
            Anim.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = -speed;
            transform.localScale = new Vector2(-1, transform.localScale.y);
            Anim.SetBool("isRunning", true);
        }
        else
        {
            Anim.SetBool("isRunning", false);
        }



    }

    //for deubgs
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}

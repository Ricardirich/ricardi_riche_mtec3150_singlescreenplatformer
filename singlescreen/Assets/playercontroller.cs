using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float movementSpeed;
    private float xMove;
    private float xVelocity;
    private Rigidbody2D rb;
    public float jumpspeed;

    private bool jumpFlag = false;
    public LayerMask ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        // transform.Translate(xMove * movementSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
        {
            jumpFlag = true;
        }

    }

    private void FixedUpdate()
    {
        float xVelocity = xMove * movementSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, 0);

        if (jumpFlag)
        {
            rb.linearVelocityY = jumpspeed;
            jumpFlag= false;
        }
       
    }

    private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;
        return Physics2D.CircleCast(transform.position,radius,Vector2.down,dist,ground);

    }
}

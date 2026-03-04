using UnityEditorInternal;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed;
    public int hp;
    public float direction;
    protected float defaultMoveSpeed;
    public LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        defaultMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed * Time.deltaTime, rb.linearVelocity.y);
    }
    protected virtual void Update()
    {
        if (!IsGrounded())
        {
            moveSpeed = 0;  
        }
        else
        {
            moveSpeed = defaultMoveSpeed;
        }
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            direction *= -1;
        }
    }
    public void DecrementHp(int damage)
    {
        if (hp - damage > 0)
        {
            hp -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    protected bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist,groundLayer);
    }
}
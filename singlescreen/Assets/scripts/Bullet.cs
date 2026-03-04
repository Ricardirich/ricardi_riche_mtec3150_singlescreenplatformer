using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public Vector2 direction;
    private Rigidbody2D rb;

    private SpriteRenderer sr;
    [HideInInspector] public Color col;

    public int damageAmount = 1;
    private object collison;

    [HideInInspector] public bool isPlayerBullet = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = col;
    }

    //public void SetColor(Color col)
   // {

    //    sr.color = col; 
   // }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.GetComponent<Enemy>() !=null)
        //  {

        // }   

        if (collision.gameObject.CompareTag("Enemy") && isPlayerBullet)
        {
            Enemy enemyHit = collision.gameObject.GetComponent<Enemy>();
            enemyHit.DecrementHp(damageAmount);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && !isPlayerBullet )
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            player.IncrementHp(-damageAmount);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
          
            Destroy(gameObject);
            return;
        }
        
            
            Destroy(gameObject);
        
    }

}
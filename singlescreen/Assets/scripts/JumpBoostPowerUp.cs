using UnityEngine;

public class JumpBoostPowerUp : PowerUp
{
    public float jumpMultiplier = 1.8f;
    private float originalJumpSpeed;

    protected override void Start()
    {
        base.Start();
      
      
    }

    public override void ApplyEffect()
    {
        base.ApplyEffect();

        originalJumpSpeed = player.jumpSpeed;
        player.jumpSpeed *= jumpMultiplier;
    }

    protected override void NegateEffect()
    {
        player.jumpSpeed = originalJumpSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect();
            sr.enabled = false; 
        }
    }
}
using UnityEngine;

public class FireSpeedPowerUp : PowerUp
{
    public float fireRateMultiplier = 0.4f; // smaller = faster
    private float originalFireRate;

    protected override void Start()
    {
        
        base.Start();
    }

    public override void ApplyEffect()
    {
        base.ApplyEffect();

        originalFireRate = player.fireRate;
        player.fireRate *= fireRateMultiplier;
    }

    protected override void NegateEffect()
    {
        player.fireRate = originalFireRate;
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
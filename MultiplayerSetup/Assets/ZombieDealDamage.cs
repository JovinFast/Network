using UnityEngine;
using Alteruna;

public class ZombieDealDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageInterval = 3f;
    private Alteruna.Avatar avatar;
    public bool canDealDamage = true;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!avatar.IsMe) return;
            if (canDealDamage)
            {
                // Deal damage to the player
                Health playerHealth = collision.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }

                // Disable damage dealing temporarily
                canDealDamage = false;
                Invoke("EnableDamage", damageInterval);
            }
        }
    }

    private void EnableDamage()
    {
        canDealDamage = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class HealthPickUp : AttributesSync
{
    int healthAmount = 1;
   
    [SerializeField] AudioClip healthSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out Alteruna.Avatar _avatar) && _avatar.IsMe)
            {
                if (other.GetComponent<Alteruna.Avatar>().IsMe)
                {
                    AudioSource.PlayClipAtPoint(healthSound,transform.position);
                    if(other.GetComponent<Health>().currentHealth < 10)
                    {
                        other.GetComponent<Health>().currentHealth += healthAmount;
                    }
                    else if (other.GetComponent<Health>().currentHealth > 10)
                    {
                        other.GetComponent<Health>().currentHealth = 10;
                    }
                }
            }
            InvokeRemoteMethod(nameof(DestroyPowerUp), UserId.AllInclusive);
        }
    }
    [SynchronizableMethod]
    private void DestroyPowerUp()
    {
        Destroy(gameObject);
    }

}

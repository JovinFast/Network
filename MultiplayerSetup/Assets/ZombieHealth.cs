using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class ZombieHealth : AttributesSync
{

    float health;
    private void Start()
    {
        health = 50;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
        }

        if (health <= 0)
        {
            InvokeRemoteMethod(nameof(DestroyZombie), UserId.AllInclusive);
        }
    }

    [SynchronizableMethod]
    private void DestroyZombie()
    {
        Destroy(gameObject);
    }
}

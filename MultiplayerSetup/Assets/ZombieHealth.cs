using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class ZombieHealth : AttributesSync
{

    [SynchronizableField]float health;
    private void Start()
    {
        health = 50;
    }

    private void Update()
    {
        
        if (health <= 0)
        {
            InvokeRemoteMethod(nameof(DestroyZombie), UserId.AllInclusive);
            ///DestroyZombie();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
        }

    }

    [SynchronizableMethod]
    private void DestroyZombie()
    {
        Destroy(gameObject);
    }
}

using Alteruna;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeObject : MonoBehaviour
{
    private RigidbodySynchronizable rb;

    public float grenadeSpeed;
    public float damage;
    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        rb = GetComponent<RigidbodySynchronizable>();
        rb.AddForce(transform.forward * grenadeSpeed, ForceMode.Impulse);
        Invoke(nameof(Explode), 2);
    }

    void Explode()
    {
        spawner.Spawn("GrenadeExplosion", transform.position);
        Destroy(gameObject);
    }
}
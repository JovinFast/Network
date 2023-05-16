using Alteruna;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private RigidbodySynchronizable rb;
    
    public float bulletSpeed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<RigidbodySynchronizable>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

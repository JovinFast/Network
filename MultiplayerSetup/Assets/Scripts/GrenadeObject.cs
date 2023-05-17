using Alteruna;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeObject : MonoBehaviour
{
    private RigidbodySynchronizable rb;

    public float grenadeSpeed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<RigidbodySynchronizable>();
        rb.AddForce(transform.forward * grenadeSpeed, ForceMode.Impulse);
        Destroy(gameObject, 3);
    }
}

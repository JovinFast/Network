using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public float explosionDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.1f);
    }

    // Update is called once per frame
}

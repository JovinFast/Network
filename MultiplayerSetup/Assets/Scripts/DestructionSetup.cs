using Alteruna;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Alteruna;
using UnityEngine.Android;

public class DestructionSetup : MonoBehaviour
{
    public float explosionForce;
    public float upwardModifier;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform part in transform)
        {
            part.AddComponent<RigidbodySynchronizable>();
            part.AddComponent<Alteruna.Avatar>();
            //part.AddComponent<Rigidbody>();
            //part.AddComponent<MeshCollider>();
            //part.GetComponent<MeshCollider>().convex = true;
        }

        foreach (Transform part in transform)
        {
            part.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, upwardModifier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

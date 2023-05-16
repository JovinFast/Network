using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    AudioSource aS;
    private Alteruna.Avatar avatar;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            if (other.GetComponent<Alteruna.Avatar>().IsMe) aS.Play();
        }
    }
}

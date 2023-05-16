using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FieldOfView : MonoBehaviour
{
    Alteruna.Avatar avatar;


    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
    }

    // Start is called before the first frame update
    void Start()
    {

        if (!avatar.IsMe)
        {
            enabled = false;
            return;
        }
        
        if(avatar.IsMe)
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
            GetComponentInChildren<Light>().enabled = true;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!avatar.IsMe) return;
            Debug.Log(other.gameObject.name);
        if(other.CompareTag("Player"))
        {
            Debug.Log("Finding playermesh");
            if (!other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                other.GetComponentInChildren<MeshRenderer>().enabled = true;
                other.GetComponentInChildren<Light>().enabled = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!avatar.IsMe) return;
            if (other.CompareTag("Player"))
        {
            if(!other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                other.GetComponentInChildren<MeshRenderer>().enabled = false;
                other.GetComponentInChildren<Light>().enabled = false;
            }
        }
            
    }
}

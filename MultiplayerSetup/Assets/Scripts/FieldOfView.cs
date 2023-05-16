using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FieldOfView : MonoBehaviour
{
    Alteruna.Avatar avatar;

    // Start is called before the first frame update
    void Start()
    {
        if (!avatar.IsMe)
        {
            enabled = false;
            return;
        }
        avatar = GetComponent<Alteruna.Avatar>();
        if(avatar.IsMe)
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
            GetComponentInChildren<Light>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.CompareTag("Player"))
        {
            Debug.Log("Finding playermesh");
            if (other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                Debug.Log("checks if me");
                return;
            }

            other.GetComponentInChildren<MeshRenderer>().enabled = true;
            other.GetComponentInChildren<Light>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                return;
            }
            other.GetComponentInChildren<MeshRenderer>().enabled = false;
            other.GetComponentInChildren<Light>().enabled = false;
        }
    }
}

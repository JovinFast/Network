using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    Alteruna.Avatar avatar;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        if(avatar.IsMe)
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
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
        }
    }
}
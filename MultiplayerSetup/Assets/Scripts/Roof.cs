using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Roof : MonoBehaviour
{
    private MeshRenderer roofMesh;

    // Start is called before the first frame update
    void Start()
    {
        roofMesh= GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

      

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("finding player");
            if (other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                Debug.Log(other.gameObject.name);
                roofMesh.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out Alteruna.Avatar avatar) && avatar.IsMe)
            {
                roofMesh.enabled = true;
            }
        }
    }
}

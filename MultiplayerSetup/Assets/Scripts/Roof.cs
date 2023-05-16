using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Roof : MonoBehaviour
{
    private MeshRenderer roofMesh;
    TurnOnOffWindSound windSound;

    // Start is called before the first frame update
    void Start()
    {
        windSound = FindObjectOfType<TurnOnOffWindSound>();
        roofMesh = GetComponent<MeshRenderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("finding player");
            if (other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                windSound.TurnDownWind();
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
                windSound.TurnUpWind();
                roofMesh.enabled = true;
            }
        }
    }
}

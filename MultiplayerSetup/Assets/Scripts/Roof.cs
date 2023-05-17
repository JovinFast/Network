using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Roof : MonoBehaviour
{
    public GameObject roofPartsPrefab;
    private GameObject roofPartObject;
    private MeshRenderer roofMesh;
    TurnOnOffWindSound windSound;
    public GameObject[] supportPoints;
    public int destroyedSupports;
    public int requiredSupports = 4;
    public bool isNotSupported;
    private bool isDestroyed;
    public int destroyedWalls;

    // Start is called before the first frame update
    void Start()
    {
        windSound = FindObjectOfType<TurnOnOffWindSound>();
        roofMesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
       if(destroyedWalls >= requiredSupports && !isDestroyed)
        {
            isDestroyed = true;
            SpawnRoofParts();
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("finding player");
            if (other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                windSound.TurnDownWind();
                //Debug.Log(other.gameObject.name);
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

    //private void CheckSupportPoints()
    //{
    //    foreach(GameObject point in supportPoints)
    //    {
    //        RaycastHit hit;
    //        Physics.Raycast(point.transform.position, -point.transform.right, out hit);
    //        Debug.Log(hit.collider.name);
    //        Debug.DrawRay(point.transform.position, -point.transform.right, Color.red, 10);


    //        if (!hit.collider.CompareTag("Wall") || hit.collider == null)
    //        {
    //            destroyedSupports++;
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //    if(destroyedSupports >= requiredSupports) 
    //    {
    //        isNotSupported = true;
    //    }
    //}

    private void SpawnRoofParts()
    {
        roofPartObject = Instantiate(roofPartsPrefab, transform.position, transform.rotation);
        roofPartObject.transform.localScale = transform.localScale;
    }
}

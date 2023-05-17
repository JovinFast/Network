using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FieldOfView : MonoBehaviour
{
    Alteruna.Avatar avatar;
    private GameObject enemyObject;
    private bool isInRange;
    private float rayDistance = 100f;


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

    private void Update()
    {
        if(isInRange)
        {
            EnemyRaycast(enemyObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (!avatar.IsMe) return;
            //Debug.Log(other.gameObject.name);

        if(other.CompareTag("Player"))
        {
            Debug.Log("Finding playermesh");
            if (!other.GetComponent<Alteruna.Avatar>().IsMe)
            {
                Debug.Log("Enter Trigger");
                isInRange = true;
                enemyObject = other.gameObject;

                //other.GetComponentInChildren<MeshRenderer>().enabled = true;
                //other.GetComponentInChildren<Light>().enabled = true;
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
                Debug.Log("Exit Trigger");
                isInRange = false;
                enemyObject = null;
                other.GetComponentInChildren<MeshRenderer>().enabled = false;
                other.GetComponentInChildren<Light>().enabled = false;
            }
        }
            
    }

    private void EnemyRaycast(GameObject enemy)
    {
        Debug.Log("is raycasting");
        Vector3 rayDirection = enemy.transform.position - transform.position;
        RaycastHit hit;
        Physics.Raycast(transform.position, rayDirection, out hit, rayDistance);
        Debug.Log(hit.collider.gameObject.name);
        Debug.DrawRay(transform.position, rayDirection, Color.magenta);
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hitting Player");
            enemy.GetComponentInChildren<MeshRenderer>().enabled = true;
            enemy.GetComponentInChildren<Light>().enabled = true;
        }
        else
        {
            enemy.GetComponentInChildren<MeshRenderer>().enabled = false;
            enemy.GetComponentInChildren<Light>().enabled = false;
        }
    }
}

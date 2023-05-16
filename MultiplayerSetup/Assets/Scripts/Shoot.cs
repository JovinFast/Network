using Alteruna;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject pivotPoint;
    public GameObject bulletPrefab;
    public Alteruna.Avatar avatar;
    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        avatar= GetComponent<Alteruna.Avatar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe)
            return;

        if(Input.GetMouseButtonDown(0)) 
        {
            spawner.Spawn(1, pivotPoint.transform.position, pivotPoint.transform.rotation);
            //Instantiate(bulletPrefab, pivotPoint.transform.position, pivotPoint.transform.rotation);
        }
    }
}

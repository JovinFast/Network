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

    [SerializeField] float decreaseAmount;
    
    private float reloadSpeed = 2;
    private float reloadSpeedStart;
    

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        avatar= GetComponent<Alteruna.Avatar>();
        reloadSpeedStart = reloadSpeed;
        reloadSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe)
            return;
        reloadSpeed -=  decreaseAmount * Time.deltaTime;
        if (reloadSpeed > 0) return; 
        if(Input.GetMouseButtonDown(0)) 
        {
            spawner.Spawn(1, pivotPoint.transform.position, pivotPoint.transform.rotation);
            reloadSpeed = reloadSpeedStart;
            //Instantiate(bulletPrefab, pivotPoint.transform.position, pivotPoint.transform.rotation);
        }
    }
}

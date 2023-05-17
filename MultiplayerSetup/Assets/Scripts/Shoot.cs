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
    public float reloadSpeedStart;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        avatar = GetComponent<Alteruna.Avatar>();
        reloadSpeedStart = reloadSpeed;
        reloadSpeed = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        if (!avatar.IsMe)
        {
            enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        reloadSpeed -=  decreaseAmount * Time.deltaTime;
        if (reloadSpeed > 0) return; 
        if(Input.GetMouseButtonDown(0)) 
        {
            spawner.Spawn(0, pivotPoint.transform.position, pivotPoint.transform.rotation);
            reloadSpeed = reloadSpeedStart;
            //Instantiate(bulletPrefab, pivotPoint.transform.position, pivotPoint.transform.rotation);
        }
    }
    
    public void DecreaseReloadSpeed()
    {
        if (reloadSpeedStart > 0)
        {
            reloadSpeedStart -= 0.5f;
        }
    }

    public void ResetFireRate()
    {
        reloadSpeedStart = 2;
        reloadSpeed = 2;
    }
}

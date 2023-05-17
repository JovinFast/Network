using Alteruna;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{
    public GameObject pivotPoint;
    public GameObject grenadePrefab;
    public Alteruna.Avatar avatar;
    private Spawner spawner;

    [SerializeField] float decreaseAmount;

    public float chargeUp;
    public float maxCharge;


    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        avatar = GetComponent<Alteruna.Avatar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe)
            return;
        if (Input.GetMouseButton(1))
        {
            while (chargeUp < maxCharge)
            {
                chargeUp += Time.deltaTime;
            }
            if (Input.GetMouseButtonUp(1) && chargeUp > 0)
            {
                spawner.Spawn("Grenade", pivotPoint.transform.position, pivotPoint.transform.rotation);
                chargeUp = 0;
            }
            //Instantiate(bulletPrefab, pivotPoint.transform.position, pivotPoint.transform.rotation);
        }
    }
}

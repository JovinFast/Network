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
    public float cooldown = 3;

    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
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
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && cooldown < 0)
        {
            spawner.Spawn("Grenade", pivotPoint.transform.position, pivotPoint.transform.rotation);
            //Instantiate(bulletPrefab, pivotPoint.transform.position, pivotPoint.transform.rotation);
            cooldown = 3;
        }
    }
}

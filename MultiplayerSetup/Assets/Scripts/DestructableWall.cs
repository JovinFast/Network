using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Alteruna;
using System.Runtime.InteropServices;

public class DestructableWall : MonoBehaviour
{
    public GameObject wallPartsPrefab;
    private GameObject wallPartObject;
    public float health;
    public float currentHealth;
    public bool isDestroyed;


    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = false;
        currentHealth = health;
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= collision.gameObject.GetComponent<Bullet>().damage;
        }

        if (currentHealth <= 0.0f && !isDestroyed)
        {
            isDestroyed = true;
            SpawnWallParts();
            Destroy(gameObject);
        }
    }

    private void SpawnWallParts()
    {
        //spawner.Spawn(0, transform.position, transform.rotation, transform.localScale);
        wallPartObject = Instantiate(wallPartsPrefab, transform.position, transform.rotation);
        wallPartObject.transform.localScale = transform.localScale;
    }
}

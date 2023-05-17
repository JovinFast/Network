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
    public Roof roof;
    public float health;
    public float currentHealth;
    public bool isDestroyed;


    // Start is called before the first frame update
    void Start()
    {
        roof = transform.parent.GetComponentInChildren<Roof>();
        isDestroyed = false;
        currentHealth = health;
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
            if (roof != null)
            {
                roof.destroyedWalls++;
            }
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

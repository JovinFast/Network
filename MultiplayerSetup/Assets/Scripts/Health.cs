using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class Health : AttributesSync
{
    [SerializeField]List<Transform> respawnPoints = new List<Transform>();
    public float playerHealth;
    [SynchronizableField] public float currentHealth;
    Shoot shootScript;
    private Alteruna.Avatar avatar;
    [SerializeField]GameObject[] PowerUps;
     private Spawner spawner;
    Vector3 deathLocation;

    


    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
        shootScript = GetComponent<Shoot>();
        avatar = GetComponent<Alteruna.Avatar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!avatar.IsMe)
        {
            enabled = false;
        }
        CollectObjectsWithTag();
        currentHealth = playerHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= collision.gameObject.GetComponent<Bullet>().damage;
        }

        if(currentHealth <= 0)
        {
            if (avatar.IsMe)
            {
             deathLocation = transform.position;
             Debug.Log("Player died");
             Invoke("SpawnPowerUp", 0.1f);
             Respawn();
                
            }
        }
    }

    private void SpawnPowerUp()
    {
        int randomIndex = Random.Range(2, 4);
        spawner.Spawn(randomIndex, deathLocation, transform.rotation);
        
    }
    private void Respawn()
    {
        SetNewPosition();
        ResetHealth();
        ResetFireRate();
    }

    private void ResetHealth()
    {
        currentHealth = 100;
    }
    private void ResetFireRate()
    {
        shootScript.ResetFireRate();
    }
    private void SetNewPosition()
    {

        int respawnIndex = Random.Range(0, respawnPoints.Count);
        transform.position = respawnPoints[respawnIndex].position;
    }
    private void CollectObjectsWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("RespawnPoint");

        foreach (GameObject obj in objects)
        {
           respawnPoints.Add(obj.transform);
        }
    }
}

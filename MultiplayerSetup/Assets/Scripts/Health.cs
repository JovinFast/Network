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


    private void Awake()
    {
        
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

    // Update is called once per frame
    void Update()
    {


    }

    [SynchronizableMethod]
    private void TestMethod(string myString)
    {
        Debug.Log(myString);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= collision.gameObject.GetComponent<Bullet>().damage;
        }

        if(currentHealth <= 0)
        {
            Debug.Log("Player died");
            Respawn();
        }

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

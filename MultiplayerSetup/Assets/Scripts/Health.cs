using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class Health : AttributesSync
{
    [SynchronizableField] public int health = 10;
    public float playerHealth;
    [SynchronizableField] public float currentHealth;

    private Alteruna.Avatar avatar;


    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!avatar.IsMe)
        {
            enabled = false;
        }
        currentHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {

            health -= 1;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            InvokeRemoteMethod(nameof(TestMethod), UserId.AllInclusive, "It got shown"); //0 for first one in the list
        }
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
            Destroy(avatar);
            Destroy(transform.gameObject);
        }

    }
}

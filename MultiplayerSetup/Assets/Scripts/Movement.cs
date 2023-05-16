using Alteruna;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Alteruna;

public class Movement : MonoBehaviour
{
    public float speed;
    public float force;
    public float maxSpeed;


    private Rigidbody rb;
    private float vertical;
    private float horizontal;
    public Alteruna.Avatar avatar;


    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!avatar.IsMe)
        {
            enabled = false;
            return;
        }

        //Camera.main.transform.SetParent(transform);
        //Camera.main.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");


        //transform.position += new Vector3(vertical, 0, -horizontal) * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(new Vector3(horizontal, 0, vertical) * force * Time.fixedDeltaTime);
        }
    }


}

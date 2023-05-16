using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float rotationSpeed;
    private Camera mainCam;
    private Alteruna.Avatar avatar;

    public Vector3 newDirection;

    private void Awake()
    {
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
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe) return;
            MouseAim();
    }
    private void MouseAim()
    {
        
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            newDirection = new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z);
        }
        //Vector3 newDirection = transform.position - mousePosition;
        Debug.DrawRay(transform.position, newDirection, Color.green);
        Debug.Log(newDirection.magnitude);
        if (newDirection.magnitude > 1)
            transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
    }

    
}

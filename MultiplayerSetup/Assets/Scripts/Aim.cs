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

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        avatar = GetComponent<Alteruna.Avatar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe)
            return;

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseWorldPosition);

        //Ta Daaa
        transform.rotation = Quaternion.LookRotation(new Vector3(0f, 0, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x);
        //return Mathf.Atan(a.x - b.x) * Mathf.Rad2Deg;
        //MouseAim();
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

        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
    }

    
}

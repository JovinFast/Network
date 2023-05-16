using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
public class CameraPossession : MonoBehaviour
{
    Alteruna.Avatar avatar;
    private Transform cameraTransform;
    private Vector3 camOffset;
    private float rotateSpeed = 5;
    public float damping = 1;
    public float x = 0;
    public float y = -3;
    public float z = 3;
    Aim aimScript;

    private void Awake()
    {
        aimScript = GetComponent<Aim>();
        avatar = GetComponent<Alteruna.Avatar>();
        cameraTransform = Camera.main.transform;
    }
    private void Start()
    {
        if(!avatar.IsMe)
        {
            enabled = false;
            return;
        }
    }

    private void LateUpdate()
    {
        cameraTransform.position = transform.position + new Vector3(x, y, z);
        camOffset = transform.position - cameraTransform.position;

        //Follow
        //Vector3 camPosition = transform.position + camOffset;
        //cameraTransform.position = camPosition;
        //Vector3 position = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * damping);
        //cameraTransform.position = position;

        //rotation
        //float currentAngle = cameraTransform.eulerAngles.y;
        //float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        float horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
        cameraTransform.transform.Rotate(0, horizontal, 0);

        float desiredAngle = transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        cameraTransform.position = transform.position + (rotation * camOffset);

        cameraTransform.LookAt(transform);
    }
}

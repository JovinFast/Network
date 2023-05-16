using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform camTarget;

    public float pLerp = 0.01f;
    public float rLerp = 0.01f;
    // Start is called before the first frame update
    private void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //if (camTarget != null)
        //{
        //    camTarget = GameObject.Find("camFollow").transform;
        //    if (camTarget.parent.GetComponent<Alteruna.Avatar>().IsMe)
        //    {

        //    }
        //    //camTarget = GameObject.Find("camFollow").transform;
        if (camTarget != null)
        {

            transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
            transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
        }
        //}

    }

    public void ApplyCamera(GameObject player)
    {
        camTarget = player.transform;
    }
}

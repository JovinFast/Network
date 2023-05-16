using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    CameraFollow cameraFollowScript;

    private void Awake()
    {
        cameraFollowScript = FindAnyObjectByType<CameraFollow>();
    }
    private void CollectObjectsWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("camFollow");

        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<Alteruna.Avatar>().IsMe)
            {
                cameraFollowScript.ApplyCamera(obj);
            }
        }
    }


}

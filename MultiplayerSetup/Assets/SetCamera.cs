using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    CameraFollow cameraFollowScript;
    [SerializeField] GameObject camFollow;
    private void Awake()
    {
        cameraFollowScript = FindAnyObjectByType<CameraFollow>();

    }
    private void Start()
    {
        CollectObjectsWithTag();
    }
    private void CollectObjectsWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<Alteruna.Avatar>().IsMe)
            {
                cameraFollowScript.ApplyCamera(camFollow);
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class SetCamera : MonoBehaviour
{
    CameraFollow cameraFollowScript;
    [SerializeField] GameObject camFollow;
    Alteruna.Avatar avatar;
    private void Awake()
    {
        cameraFollowScript = FindAnyObjectByType<CameraFollow>();
        avatar = GetComponent<Alteruna.Avatar>();

    }
    private void Start()
    {
        if (!avatar.IsMe)
        {
            enabled = false;
            return;
        }
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

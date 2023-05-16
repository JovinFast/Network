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
        cameraFollowScript.ApplyCamera(camFollow);
    }
}

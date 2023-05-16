using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineOverride : CinemachineExtension
{
    [SerializeField] private float clampAngle = 80f;
    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticalSpeed = 10f;

    private Vector3 startingRotation;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        vcam.Follow = GameObject.Find("Player").transform;
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
                startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);

            }
        }
    }
}

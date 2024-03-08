using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fovCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float zoomedInFOV = 20.0f;
    [SerializeField] float zoomedOutFOV = 40.0f;
    [SerializeField] float zoomedInSensitivity = 0.5f;
    [SerializeField] float zoomedOutSensitivity = 2.0f;


    bool zoomedInToggle = false;

    void Update()
    {
        //     // Alternative way to zoom in and out using Q key
        // if (Input.GetKey(KeyCode.Q))
        // {
        //     fovCamera.m_Lens.FieldOfView = zoomedInFOV;
        // }

        // else
        // {
        //     fovCamera.m_Lens.FieldOfView = zoomedOutFOV;
        // }

        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    private void ZoomIn()
    {
        fovCamera.m_Lens.FieldOfView = zoomedInFOV;
        zoomedInToggle = true;
        fpsController.RotationSpeed = zoomedInSensitivity;
    }

    private void ZoomOut()
    {
        fovCamera.m_Lens.FieldOfView = zoomedOutFOV;
        zoomedInToggle = false;
        fpsController.RotationSpeed = zoomedOutSensitivity;
    }

}
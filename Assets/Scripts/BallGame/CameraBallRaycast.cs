using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CameraController))]

public class CameraBallRaycast : MonoBehaviour
{
    CameraController controller;
    RaycastHit hit;
    public LayerMask layerMask;
    public GameObject ballCover;
    void Start()
    {
        controller = GetComponent<CameraController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(controller.cam.gameObject.transform.position, controller.cam.gameObject.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(controller.cam.gameObject.transform.position, controller.cam.gameObject.transform.forward * hit.distance, Color.yellow);
            ballCover.SetActive(false);
        }
        else
        {
            Debug.DrawRay(controller.cam.gameObject.transform.position, controller.cam.gameObject.transform.forward * 1000f, Color.white);
            ballCover.SetActive(true);
        }
    }
}

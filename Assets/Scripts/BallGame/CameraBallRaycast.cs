using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CameraController))]

public class CameraBallRaycast : MonoBehaviour
{
    CameraController controller;
    RaycastHit hit;
    public LayerMask layerMask;
    public Image ballCover;
    public GameObject cam;
    public float camDistance;
    private bool ballIsVisible;

    void Update()
    {
        
        Vector3 camDirection = (cam.transform.position - transform.position).normalized;

        if(Physics.Raycast(transform.position, camDirection, out hit, camDistance, layerMask))
        {
            Debug.DrawRay(transform.position, camDirection * hit.distance, Color.yellow);
            ballCover.gameObject.SetActive(true);

            Vector3 ballPos = Camera.main.WorldToScreenPoint(transform.position);
            ballCover.transform.position = ballPos;
        }
        else
        {
            Debug.DrawRay(transform.position, camDirection * camDistance, Color.white);
            ballCover.gameObject.SetActive(false);
        }

        
    }

    
}

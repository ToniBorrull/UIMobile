using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    void Update()
    {
        if(Physics.Raycast(transform.position, -cam.gameObject.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, -cam.gameObject.transform.forward * hit.distance, Color.yellow);
            ballCover.gameObject.SetActive(true);

            Vector3 ballPos = Camera.main.WorldToScreenPoint(transform.position);
            ballCover.transform.position = ballPos;
        }
        else
        {
            Debug.DrawRay(transform.position, -cam.gameObject.transform.forward * 1000f, Color.white);
            ballCover.gameObject.SetActive(false);
        }
    }
}

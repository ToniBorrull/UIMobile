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
    Color color;
    private void Start()
    {
        controller = GetComponent<CameraController>();
        color = ballCover.color;
    }
    void Update()
    {
        Vector3 viewport = controller.cam.WorldToViewportPoint(transform.position);
        if (!(viewport.x >= 0 && viewport.x <= 1 && viewport.y >= 0 && viewport.y <= 1 && viewport.z > 0)) { 

            if (viewport.z < 0)
            {
                viewport.y = -viewport.y;
                viewport *= 100000;
            }

            if (viewport.x > 1)
            {
                viewport.x = 1;
            }
            if (viewport.y > 1)
            {
                viewport.y = 1;
            }
            if (viewport.x < 0)
            {
                viewport.x = 0;
            }
            if (viewport.y < 0)
            {
                viewport.y = 0;
            }
            Debug.Log("Moverse");
            ballCover.rectTransform.anchorMin = viewport;
            ballCover.rectTransform.anchorMax = viewport;
            ballCover.gameObject.SetActive(true);
            return;
        }
        else
        {
            ballCover.gameObject.SetActive(false);
        }

        Vector3 camDirection = (cam.transform.position - transform.position).normalized;

        if(Physics.Raycast(transform.position, camDirection, out hit, camDistance, layerMask))
        {
            Debug.DrawRay(transform.position, camDirection * hit.distance, Color.yellow);
            ballCover.gameObject.SetActive(true);

            Vector3 ballPos = Camera.main.WorldToScreenPoint(transform.position);
            ballCover.transform.position = ballPos;

            color.a = .5f;
            ballCover.color = color;
        }
        else
        {
            Debug.DrawRay(transform.position, camDirection * camDistance, Color.white);
            ballCover.gameObject.SetActive(false);
        }
    }

    
}

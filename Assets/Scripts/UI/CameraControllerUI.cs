using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerUI : MonoBehaviour
{
    public CameraController controller;
    public float zoomVal;
    public float rotVal;

    float opt = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateLeft()
    {
        controller.Rotate(zoomVal);
    }

    public void RotateRight()
    {
        controller.Rotate(-zoomVal);
    }

    public void ZoomIn()
    {
        controller.Zoom(rotVal);
    }

    public void ZoomOut()
    {
        controller.Zoom(-rotVal);
    }

    public void ChangeFocus()
    {
        opt++;
        if (opt == 3)
        {
            opt = 0;
        }

        if (opt == 0)
        {
            controller.SwitchTargetBall();
        } 
        else if (opt == 1)
        {
            controller.SwitchTargetTarget();
        } 
        else
        {
            controller.SwitchTargetMiddlepoint();
        }
    }
}

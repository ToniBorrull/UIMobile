using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CameraController))]
public class CameraInput : MonoBehaviour
{
    CameraController controller;
    NewInputs input;
    float screenHeight;

    void Start()
    {
        controller = GetComponent<CameraController>();
        input = new NewInputs();
        input.Player.Enable();
        input.UI.Enable();
        screenHeight = Screen.height;
    }
    void Update()
    {
        float val = input.Player.CameraZoom.ReadValue<float>();
        if (val > 0)
        {
            controller.Zoom(-5);
        }
        else if (val < 0)
        {
            controller.Zoom(5);
        }

        //falta touch
        if (input.Player.Drag.IsPressed()) 
        {
            Vector2 mousePos = input.Player.CamRotation.ReadValue<Vector2>();
            float mouseX = mousePos.x;
            float mouseY = Mouse.current.position.ReadValue().y;

            float rotationDirection;
            if (mouseY > screenHeight / 2)
            {
                rotationDirection = 1;
            } else
            {
                rotationDirection = -1;
            }

            float rotationValue = mouseX * rotationDirection * 10 * Time.deltaTime;
            controller.Rotate(rotationValue);
        }
    }
}

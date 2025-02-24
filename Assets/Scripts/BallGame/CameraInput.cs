using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CameraController))]
public class CameraInput : MonoBehaviour
{
    CameraController controller;
    NewInputs input;
    float screenHeight;
    public Slider slider;
    public Toggle toggle;

    float camSensibility = 10;
    bool invert = false;

    void Start()
    {
        controller = GetComponent<CameraController>();
        input = new NewInputs();
        input.Player.Enable();
        input.UI.Enable();
        screenHeight = Screen.height;

        slider.onValueChanged.AddListener(updateSensibility);
        toggle.onValueChanged.AddListener(invertCam);
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

            if (invert)
            {
                rotationDirection *= -1;
            }
            float rotationValue = mouseX * rotationDirection * camSensibility * Time.deltaTime;
            controller.Rotate(rotationValue);
        }
    }

    void updateSensibility(float value)
    {
        camSensibility = value;
    }

    void invertCam(bool value)
    {
        invert = value;
    }

}

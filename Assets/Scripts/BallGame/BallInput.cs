using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BallController))]
public class BallInput : MonoBehaviour
{
    NewInputs input;
    BallController controller;
    public JoystickInput joystick;

    private void Start()
    {
        controller = GetComponent<BallController>();
        input = new NewInputs();
        input.Player.Enable();
        input.UI.Enable();
    }
    void Update()
    {
        controller.Move(input.Player.Move.ReadValue<Vector2>());
        controller.Move(joystick.movement);
        if (input.Player.Jump.WasPressedThisFrame())
        {
            controller.Jump();
        }
    }
}

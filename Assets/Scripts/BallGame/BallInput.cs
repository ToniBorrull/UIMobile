using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallController))]
public class BallInput : MonoBehaviour
{
    NewInputs input;
    BallController controller;
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
        if (input.Player.Jump.WasPressedThisFrame())
        {
            controller.Jump();
        }
    }
}

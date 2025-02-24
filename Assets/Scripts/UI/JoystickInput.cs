using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JoystickInput : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform middlePoint;
    public RectTransform joystick;
    public float maxMovement = 50f;
    public Vector2 movement;

    private Vector2 initialPos;
    private void Start()
    {
        initialPos = new Vector2(-25, -25);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.position);

        Vector2 direction = (eventData.position - initialPos) - initialPos;
        movement = Vector2.ClampMagnitude(direction, maxMovement);
        joystick.anchoredPosition = movement;
        movement.Normalize();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joystick.anchoredPosition = initialPos;
        movement = Vector2.zero;
    }
}

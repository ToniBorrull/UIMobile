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

    public Vector2 initialPos;

    private void Start()
    {
        initialPos = joystick.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)middlePoint.position;

        movement = Vector2.ClampMagnitude(dir, maxMovement);
        joystick.anchoredPosition = initialPos + movement;

        movement.Normalize();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joystick.anchoredPosition = initialPos;
        movement = Vector2.zero;
    }
}

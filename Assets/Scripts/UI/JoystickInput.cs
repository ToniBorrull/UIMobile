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
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        Vector2 direction = eventData.position - (Vector2)middlePoint.position;
        movement = Vector2.ClampMagnitude(direction, maxMovement);
        joystick.anchoredPosition = movement;
        movement.Normalize();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joystick.anchoredPosition = middlePoint.rect.position;
        movement = middlePoint.rect.position;

    }
}

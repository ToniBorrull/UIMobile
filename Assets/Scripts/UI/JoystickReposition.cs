using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoystickReposition : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform zone;
    public RectTransform joystick;
    public JoystickInput joystickInput;
    Vector2 initialPos;
    public Toggle toggle;
    public bool repo = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = zone.anchoredPosition;
        toggle.onValueChanged.AddListener(onToggle);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(repo)
        {
            zone.position = eventData.position;
            joystickInput.initialPos = joystick.anchoredPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (repo)
        {
            Vector2 dir = eventData.position - (Vector2)zone.position;

            joystickInput.movement = Vector2.ClampMagnitude(dir, joystickInput.maxMovement);
            joystick.anchoredPosition = joystickInput.initialPos + joystickInput.movement;

            joystickInput.movement.Normalize();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (repo)
        {
            joystick.anchoredPosition = joystickInput.initialPos;
            joystickInput.movement = Vector2.zero;
        }
    }

    void onToggle(bool val)
    {
        if (!val)
        {
            zone.position = initialPos;
            repo = false;
        } else
        {
            repo = true;
        }
    }
}

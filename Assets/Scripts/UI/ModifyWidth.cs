using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ModifyWidth : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public LateralMenu menu;
    RectTransform handle;
    private float minPos;
    private float maxPos;
    public RectTransform canvas;
    public float minScreenPos = 0.45f;
    public float maxScreenPos = 0.6f;
    private void Start()
    {
        handle = GetComponent<RectTransform>();
        GetCanvasViewport();
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetCanvasViewport();
        float num = Mathf.Clamp(menu.menuPanel.sizeDelta.x + eventData.delta.x, minPos, maxPos);
        menu.menuPanel.sizeDelta = new Vector2(num, menu.menuPanel.sizeDelta.y);
        Debug.Log(num);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetCanvasViewport();
        menu.visibleWidth = menu.menuPanel.sizeDelta.x;
    }

    private void GetCanvasViewport()
    {
        minPos = canvas.rect.width * minScreenPos;
        maxPos = canvas.rect.width * maxScreenPos;
    }
}

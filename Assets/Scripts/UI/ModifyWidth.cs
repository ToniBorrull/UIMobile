using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ModifyWidth : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public LateralMenu menu;
    RectTransform handle;
    public float minPos;
    public float maxPos;
    public RectTransform canvas;
    private void Start()
    {
        handle = GetComponent<RectTransform>();
        minPos = canvas.rect.width * 0.2f;
        maxPos = canvas.rect.width * 0.7f;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        minPos = canvas.rect.width * 0.2f;
        maxPos = canvas.rect.width * 0.7f;
        float num = Mathf.Clamp(menu.menuPanel.sizeDelta.x + eventData.delta.x, minPos, maxPos);
        menu.menuPanel.sizeDelta = new Vector2(num, menu.menuPanel.sizeDelta.y);
        Debug.Log(num);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        menu.visibleWidth = menu.menuPanel.sizeDelta.x;
    }
}

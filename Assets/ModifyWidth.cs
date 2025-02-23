using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ModifyWidth : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public LateralMenu menu;
    RectTransform handle;
    private void Start()
    {
        handle = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        menu.menuPanel.sizeDelta = new Vector2(eventData.position.x, menu.menuPanel.sizeDelta.y);
        handle.anchoredPosition = new Vector2(eventData.position.x, handle.anchoredPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        menu.visibleWidth = menu.menuPanel.sizeDelta.x;
    }
}

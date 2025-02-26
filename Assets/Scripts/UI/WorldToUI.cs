using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class WorldToUI : MonoBehaviour
{
    Camera cam;
    RectTransform rectTransform;
    RectTransform canvasRect;
    public Transform target;
    public Image targetColor;
    bool targetIsVisible;
    Color color;
    private void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        color = targetColor.color;

    }

    void Update()
    {
         Vector3 pos = cam.WorldToViewportPoint(target.position);
        
        if(pos.z < 0)
        {
            pos.x = -pos.x;
            pos.y = -pos.y;
            pos *= 100000;
        }

        if(pos.x > 1)
        {
            pos.x = 1;
        }
        if(pos.y > 1)
        {
            pos.y = 1;
        }
        if (pos.x < 0)
        {
            pos.x = 0;
        }
        if (pos.y < 0)
        {
            pos.y = 0;
        }
       
        rectTransform.anchorMin = pos;
        rectTransform.anchorMax = pos;

        TargetVisible(target.position);
    }
    private void TargetVisible(Vector3 target)
    {
        Vector3 viewport = cam.WorldToViewportPoint(target);
        if (viewport.x >= 0 && viewport.x <= 1 && viewport.y >= 0 && viewport.y <= 1 && viewport.z > 0)
        {
            targetIsVisible = true;
            color.a = .5f;
            targetColor.color = color;
            
        }
        else
        {
            targetIsVisible = false;
            color.a = 1f;
            targetColor.color = color;
        }
    }
}

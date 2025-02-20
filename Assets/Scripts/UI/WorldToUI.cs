using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class WorldToUI : MonoBehaviour
{
    Camera cam;
    RectTransform rectTransform;
    RectTransform canvasRect;
    public Transform target;
    private void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
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

        Debug.Log(pos);
    }
}

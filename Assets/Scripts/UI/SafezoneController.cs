using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafezoneController : MonoBehaviour
{
    public RectTransform panel;
    public Slider safeX;
    public Slider safeY;

    void Start()
    {
        safeX.onValueChanged.AddListener(updateX);
        safeY.onValueChanged.AddListener(updateY);
    }

    void updateX(float value)
    {
        float width = Screen.width;
        panel.offsetMin = new Vector2(width * value * 0.5f, panel.offsetMin.y);
        panel.offsetMax = new Vector2(-width * value * 0.5f, panel.offsetMax.y);
    }

    void updateY(float value)
    {
        float height = Screen.height;
        panel.offsetMin = new Vector2(panel.offsetMin.x, height * value * 0.5f);
        panel.offsetMax = new Vector2(panel.offsetMax.x, -height * value * 0.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafezoneController : MonoBehaviour
{
    public RectTransform panel;
    public Slider safeX;
    public Slider safeY;

    Vector2 startSize;

    void Start()
    {
        safeX.onValueChanged.AddListener(updateX);
        safeY.onValueChanged.AddListener(updateY);
        startSize = new Vector2(panel.rect.width, panel.rect.height);
    }

    void updateX(float value)
    {
        panel.offsetMin = new Vector2(startSize.x * value, panel.offsetMin.y);
        panel.offsetMax = new Vector2(startSize.x * -value, panel.offsetMax.y);
    }

    void updateY(float value)
    {
        panel.offsetMin = new Vector2(panel.offsetMin.x, startSize.y * value);
        panel.offsetMax = new Vector2(panel.offsetMax.x, startSize.y * -value);
    }

}

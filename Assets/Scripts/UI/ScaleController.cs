using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    public CanvasScaler canvasScaler;
    public Slider scaleSlider;
    float baseX = 800f;
    float baseY = 800f;

    void Start()
    {
        scaleSlider.onValueChanged.AddListener(UpdateUIScale);
        baseX = canvasScaler.referenceResolution.x;
        baseY = canvasScaler.referenceResolution.y;
    }
    void UpdateUIScale(float value)
    {
        canvasScaler.referenceResolution = new Vector2(baseX * value , baseY * value);
    }
}

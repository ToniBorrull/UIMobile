using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    public CanvasScaler canvasScaler;
    public Slider scaleSlider;
    public float baseX = 400f;
    public float baseY = 1600f;

    void Start()
    {
        scaleSlider.onValueChanged.AddListener(UpdateUIScale);
        scaleSlider.value = 1f;
        baseX = canvasScaler.referenceResolution.x;
        baseY = canvasScaler.referenceResolution.y;
    }
    private void UpdateUIScale(float value)
    {
        canvasScaler.referenceResolution = new Vector2(baseX * value , baseY * value);
    }
}

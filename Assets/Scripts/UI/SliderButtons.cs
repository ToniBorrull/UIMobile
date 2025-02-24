using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderButtons : MonoBehaviour
{
    Slider slider;
    public TMP_InputField inputField;
    public float changeValue;

    private void Start()
    {
        slider = GetComponent<Slider>();
        inputField.onValueChanged.AddListener(changeSliderValue);
    }

    public void plusButton()
    {
        slider.value += changeValue;
    }

    public void minusButton()
    {
        slider.value -= changeValue;
    }

    void changeSliderValue(string value)
    {
        slider.value = float.Parse(value);
    }
}

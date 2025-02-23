using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.EventSystems;


public class LateralMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public float transitionSpeed = 5f;
    public TMP_Text toggleButton;
    private float hiddenWidth = 0;
    public float visibleWidth;
    private bool isVisible = false;
    public GameObject widthHandler;
  

    void Start() 
    {
        visibleWidth = menuPanel.rect.width;
        menuPanel.sizeDelta = new Vector2(hiddenWidth, menuPanel.sizeDelta.y);
        widthHandler.SetActive(false);
    }

    public void ToggleMenu()
    {
        StopAllCoroutines();
        if (!isVisible)
        {
            toggleButton.text = "Close";
            StartCoroutine(AnimateMenu(visibleWidth));
            widthHandler.SetActive(true);
        }
        else if (isVisible)
        {
            toggleButton.text = "Open";
            StartCoroutine(AnimateMenu(hiddenWidth));
            widthHandler.SetActive(false);
        }
        isVisible = !isVisible;
    }

    IEnumerator AnimateMenu(float width)
    {
        while (Mathf.Abs(menuPanel.sizeDelta.x - width) > 0.1f)
        {
            menuPanel.sizeDelta = Vector2.Lerp(menuPanel.sizeDelta, new Vector2(width, menuPanel.sizeDelta.y), Time.deltaTime * transitionSpeed);
            yield return null;
        }
        menuPanel.sizeDelta = new Vector2(width, menuPanel.sizeDelta.y); 
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LateralMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public float transitionSpeed = 5f;
    public Image toggleButton;
    private float hiddenWidth = 0;
    public float visibleWidth;
    private bool isVisible = false;
    public GameObject widthHandler;
    public Sprite toggleImage;
    public Sprite closeImage;
  

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
            toggleButton.sprite = closeImage;
            StartCoroutine(AnimateMenu(visibleWidth));
            widthHandler.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (isVisible)
        {
            toggleButton.sprite = toggleImage;
            StartCoroutine(AnimateMenu(hiddenWidth));
            widthHandler.SetActive(false);
            Time.timeScale = 1f;
        }
        isVisible = !isVisible;
    }

    IEnumerator AnimateMenu(float width)
    {
        while (Mathf.Abs(menuPanel.sizeDelta.x - width) > 0.1f)
        {
            menuPanel.sizeDelta = Vector2.Lerp(menuPanel.sizeDelta, new Vector2(width, menuPanel.sizeDelta.y), Time.unscaledDeltaTime * transitionSpeed);
            yield return null;
        }
        menuPanel.sizeDelta = new Vector2(width, menuPanel.sizeDelta.y);
    }

}
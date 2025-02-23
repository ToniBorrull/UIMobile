using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class LateralMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public float transitionSpeed = 5f;
    public TMP_Text toggleButton;
    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;
    private bool isVisible = false;
  

    void Start() 
    {
        visiblePosition = menuPanel.anchoredPosition;
        hiddenPosition = new Vector2(menuPanel.anchoredPosition.x - menuPanel.rect.width, menuPanel.anchoredPosition.y);

        menuPanel.anchoredPosition = hiddenPosition;
    }

    public void ToggleMenu()
    {
        StopAllCoroutines();
        if (!isVisible)
        {
            toggleButton.text = "Close";
            StartCoroutine(AnimateMenu(visiblePosition));
        }
        else if (isVisible)
        {
            toggleButton.text = "Open";
            StartCoroutine(AnimateMenu(hiddenPosition));
        }
        isVisible = !isVisible;
        
    }

    IEnumerator AnimateMenu(Vector2 targetPosition)
    {
        while (Vector2.Distance(menuPanel.anchoredPosition, targetPosition) > 0.1f)
        {
            menuPanel.anchoredPosition = Vector2.Lerp(menuPanel.anchoredPosition, targetPosition, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        menuPanel.anchoredPosition = targetPosition; 
    }

}
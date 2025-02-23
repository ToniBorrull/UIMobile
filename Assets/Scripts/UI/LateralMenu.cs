using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class LateralMenu : MonoBehaviour
{
    NewInputs input;
    public RectTransform menuPanel;
    public float transitionSpeed = 5f;
    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;
    private bool isVisible = false;

    void Start()
    {
        input = new NewInputs();
        // Guarda la posici�n visible y oculta del men�
        visiblePosition = menuPanel.anchoredPosition;
        hiddenPosition = new Vector2(menuPanel.anchoredPosition.x - menuPanel.rect.width, menuPanel.anchoredPosition.y);

        // Inicia en la posici�n oculta
        menuPanel.anchoredPosition = hiddenPosition;
    }

    public void ToggleMenu()
    {
        StopAllCoroutines(); // Detiene cualquier transici�n en curso
        StartCoroutine(AnimateMenu(isVisible ? hiddenPosition : visiblePosition));
        isVisible = !isVisible;
    }

    IEnumerator AnimateMenu(Vector2 targetPosition)
    {
        while (Vector2.Distance(menuPanel.anchoredPosition, targetPosition) > 0.1f)
        {
            menuPanel.anchoredPosition = Vector2.Lerp(menuPanel.anchoredPosition, targetPosition, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        menuPanel.anchoredPosition = targetPosition; // Ajusta la posici�n final
    }

}
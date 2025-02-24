using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public RectTransform options1;
    public RectTransform options2;

    public ScrollRect viewport;

    public void ChangeOptions1()
    {
        options2.gameObject.SetActive(false);
        options1.gameObject.SetActive(true);
        viewport.viewport = options1;
    }
    public void ChangeOptions2()
    {
        options1.gameObject.SetActive(false);
        options2.gameObject.SetActive(true);
        viewport.viewport = options2;
    }
}

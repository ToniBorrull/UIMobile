using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public RectTransform options1;
    public RectTransform options2;

    public RectTransform options1Content;
    public RectTransform options2Content;

    public ScrollRect viewport;

    public void ChangeOptions1()
    {
        options2.gameObject.SetActive(false);
        options1.gameObject.SetActive(true);
        viewport.viewport = options1;
        viewport.content = options1Content;
    }
    public void ChangeOptions2()
    {
        options1.gameObject.SetActive(false);
        options2.gameObject.SetActive(true);
        viewport.viewport = options2;
        viewport.content = options2Content;
    }
}

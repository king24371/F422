using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayImg : MonoBehaviour
{
    RectTransform rect;
    Image img;

    IEnumerator co;
    private void Start()
    {
        gameObject.SetActive(false);
        rect = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }

    public void Show()
    {
        if (co != null) return;
        gameObject.SetActive(true);
        co = CoShow();
        StartCoroutine(co);
    }

    IEnumerator CoShow()
    {
        Vector2 orignV2 = rect.sizeDelta;
        Color orignColor = img.color;
        for (float f = 0; f <= 1; f += 0.025f)
        {
            rect.sizeDelta = Vector2.Lerp(orignV2, new Vector2(350, 350), f);
            img.color = Color.Lerp(orignColor, new Color(1, 1, 1, 0), f);
            yield return null;
        }
        gameObject.SetActive(false);
        rect.sizeDelta = orignV2;
        img.color = orignColor;
        co = null;
    }
}

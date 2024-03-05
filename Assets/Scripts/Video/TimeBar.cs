using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TimeBar : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] MyPlayerVideo vp;
    Slider bar;
    void Start()
    {
        bar = GetComponent<Slider>();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (vp.isStop)
        {
            vp.CalculateNowTime(bar.value);
            vp.isStop = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        vp.isStop = true;
    }
}

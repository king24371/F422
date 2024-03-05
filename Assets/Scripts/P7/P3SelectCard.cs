using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class P3SelectCard : UI_Drag
{
    public delegate void DragEvent();
    public DragEvent _DragEvent;
    public Transform turnArea;
    public Sprite oriSpr;

    void Start()
    {
        Init();
        oriSpr = transform.GetComponent<Image>().sprite;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (turnArea.childCount > 0)
        {
            turnArea.GetChild(0).GetComponent<Animator>().enabled = false;
            turnArea.GetChild(0).GetComponent<Image>().sprite = turnArea.GetChild(0).GetComponent<P3SelectCard>().oriSpr;
            turnArea.GetChild(0).GetComponent<UI_Drag>().Back();
        }
    }

    public void ChangeCard(Sprite spr) 
    {
        GetComponent<Image>().sprite = spr;
    }
    public override void MoveOn()
    {
        transform.localPosition = Vector3.zero;
        if (_DragEvent != null)
            _DragEvent.Invoke();
    }
    public override void PointerOn()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Image>().sprite = oriSpr;
        base.PointerOn();

        if (_DragEvent != null)
            _DragEvent.Invoke();
    }
}

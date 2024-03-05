using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P5SelectCard : UI_Drag
{
    public P5Target target;
    public P5 p5;

    public int Liter;
    public int Volume;
    public GameObject Pon8, Pon5, Pon3;
    public Sprite[] volumeSprs;

    public delegate void DragEvent();
    public DragEvent _DragEvent;

    void Start()
    {
        Init();
    }

    public void ChangeCard(Sprite spr) 
    {
        GetComponent<Image>().sprite = spr;
    }
    public override void MoveOn()
    {
        //transform.localPosition = Vector3.zero;
        if (Volume == 0)
        {
            Back();
            return;
        }
        else
        {
            transform.parent.GetComponent<P5Target>().pourAnim(Liter);
            Volume = transform.parent.GetComponent<P5Target>().calcPour(Volume);
            GetComponent<Image>().sprite = volumeSprs[Volume];
        }

        gameObject.SetActive(false);
        //Back();        

        if (_DragEvent != null)
            _DragEvent.Invoke();
    }
    public override void PointerOn()
    {
        base.PointerOn();

        if (_DragEvent != null)
            _DragEvent.Invoke();
    }

    public void setVolume(int v)
    {
        Volume = v;
        GetComponent<Image>().sprite = volumeSprs[v];
    }

    public void pourOil(int liter)
    {
        StartCoroutine(waitPour(liter));
    }
    IEnumerator waitPour (int liter )
    {
        switch (liter)
        {
            case 3:
                Pon3.SetActive(true);
                break;
            case 5:
                Pon5.SetActive(true);
                break;
            case 8:
                Pon8.SetActive(true);
                break;
        }

        yield return new WaitForSeconds(1);

        switch (liter)
        {
            case 3:
                Pon3.SetActive(false);
                break;
            case 5:
                Pon5.SetActive(false);
                break;
            case 8:
                Pon8.SetActive(false);
                break;
        }
    }

    public void addOil(int first, int total)
    {
        StartCoroutine(waitAdd(first, total));
    }
    IEnumerator waitAdd(int first, int total)
    {
        var Anim = GetComponent<Animator>();
        Anim.enabled = true;
        Anim.Play($"{Liter}_{first}-{total}");

        yield return new WaitForSeconds(1);

        Anim.enabled = false;
        target.transform.GetChild(0).gameObject.SetActive(true);
        target.transform.GetChild(0).GetComponent<UI_Drag>().Back();
        p5.plusRecord();
    }

}

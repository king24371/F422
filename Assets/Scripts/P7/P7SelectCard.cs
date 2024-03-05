using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P7SelectCard : UI_Drag
{
    public P7Target target;
    public P7 p7;

    public int Liter;
    public int Volume;
    public Transform Cubes;
    public Transform Pon8, Pon5, Pon3;
    public Sprite oriSpr;
    int currentIndex = 0;
    int lastVolume;

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
            lastVolume = Volume;
            transform.parent.GetComponent<P7Target>().pourAnim(Liter, transform);
            Volume = transform.parent.GetComponent<P7Target>().calcPour(Volume);
            pourOil();
        }

        //gameObject.SetActive(false);
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

        foreach (var cube in Cubes.GetComponentsInChildren<Image>())
            cube.gameObject.SetActive(false);

        for (int i = Cubes.childCount - 1; i >= (Liter - v); i--)
        {
            if (!Cubes.GetChild(i).gameObject.activeSelf)
            {
                // 打开该子物体
                Cubes.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void Reset()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Image>().sprite = oriSpr;
        Back();
        transform.localEulerAngles = Vector3.zero;
    }

    public void pourOil()
    {
        StartCoroutine(PourOilRoutine());
        StartCoroutine(waitSecond());
    }
    IEnumerator PourOilRoutine()
    {
        for (int i = 0; i < (lastVolume - Volume); i++)
        {
            yield return StartCoroutine(waitPour());
        }
    }
    IEnumerator waitPour ()
    {
        yield return new WaitForSeconds(0.2f);

        for(int i = 0; i < Cubes.childCount; i++)
        {
            if (!Cubes.GetChild(i).gameObject.activeSelf)
                continue;
            else
            {
                Cubes.GetChild(i).gameObject.SetActive(false);
                break;
            }
        }
    }

    public void addOil(int first, int total)
    {
        StartCoroutine(AddOilRoutine(first, total));
    }
    IEnumerator AddOilRoutine(int first, int total)
    {
        for (int i = 0; i < (total - first); i++)
            yield return StartCoroutine(waitAdd(first, total));
    }
    IEnumerator waitAdd(int first, int total)
    {
        yield return new WaitForSeconds(0.2f);

        for (int i = Cubes.childCount - 1; i >= 0; i--)
        {
            if (!Cubes.GetChild(i).gameObject.activeSelf)
            {
                // 打开该子物体
                Cubes.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }

    IEnumerator waitSecond()
    {
        yield return new WaitForSeconds(1);

        Reset();
        p7.plusRecord();
    }
}

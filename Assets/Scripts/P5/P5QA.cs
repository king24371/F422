using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P5QA : MonoBehaviour
{
    public Button Round, resetBtn;
    public Button[] Tops, Sides;
    public GameObject Origin, Side, Top;
    //public Sprite[] 

    // Start is called before the first frame update
    void Start()
    {
        Round.onClick.AddListener(() =>
        {
            playAnim(Origin);
            playAnim(Side);
            playAnim(Top);
        });

        foreach(var btn in Tops)
        {
            btn.onClick.AddListener(() =>
            {
                Origin.SetActive(false);
                Side.SetActive(false);
                Top.SetActive(true);
            });
        }
        foreach(var btn in Sides)
        {
            btn.onClick.AddListener(() =>
            {
                Origin.SetActive(false);
                Top.SetActive(false);
                Side.SetActive(true);
            });
        }

        resetBtn.onClick.AddListener(Reset);
    }

    void playAnim(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.GetComponent<Animator>().enabled = true;
            obj.GetComponent<Animator>().Play(0);
            StartCoroutine(waitAnim(obj));
        }
    }

    public void Reset()
    {
        Side.SetActive(false);
        Top.SetActive(false);
        Origin.SetActive(true);
        Origin.GetComponent<Animator>().enabled = false;
    }

    IEnumerator waitAnim(GameObject obj)
    {
        yield return new WaitForSeconds(2.2f);

        obj.GetComponent<Animator>().enabled = false;
    }
}

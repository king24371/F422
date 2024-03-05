using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P4Anim : MonoBehaviour
{
    public Button putBack;
    public Image Cube, outCube;
    public GameObject Btns, Outs, Anim;

    // Start is called before the first frame update
    void Start()
    {
        putBack.onClick.AddListener(() =>
        {
            Cube.gameObject.SetActive(true);
            Cube.sprite = outCube.sprite;
            
            foreach (var btn in Btns.transform.GetComponentsInChildren<Button>())
                btn.gameObject.SetActive(true);

            Outs.SetActive(false);
            Btns.SetActive(false);
        });
    }

    public void coPaint()
    {
        StartCoroutine(waitPaint());
    }
    public void coTurn()
    {
        StartCoroutine(waitTurn());
    }

    IEnumerator waitPaint()
    {
        yield return new WaitForSeconds(2);

        Anim.SetActive(false);
        Btns.SetActive(true);
    }
    IEnumerator waitTurn()
    {
        Btns.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Btns.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P7 : MonoBehaviour
{
    public P7SelectCard Pon8, Pon5, Pon3;

    public Button Topic, resetBtn;
    public Button Eyes, Display, BackUp;
    public GameObject txtPFB;
    public GameObject topicObj, Pons;
    public GameObject[] subPons;
    public GameObject[] Roads;
    public Text recordTxt;
    public Transform Content;
    public Sprite[] eyeSprs;
    int r = 0;

    public bool isM1, isM2, isP9, isP91, isP92;

    // Start is called before the first frame update
    void Start()
    {
    //    Topic.onClick.AddListener(() =>
    //    {
    //        topicObj.SetActive(!topicObj.activeSelf);

    //        if (!topicObj.activeSelf)
    //            Pons.SetActive(true);
    //        else
    //            Pons.SetActive(false);
    //    });

        Eyes.onClick.AddListener(() =>
        {
            if (!subPons[0].activeSelf)
            {
                subPons[0].SetActive(true);
                subPons[1].SetActive(true);
                subPons[2].SetActive(true);
                Eyes.image.sprite = eyeSprs[0];
            }
            else
            {
                subPons[0].SetActive(false);
                subPons[1].SetActive(false);
                subPons[2].SetActive(false);
                Eyes.image.sprite = eyeSprs[1];
            }
        });

        Display.onClick.AddListener(() =>
        {
            foreach (var road in Roads)
                road.SetActive(true);
        });

        BackUp.onClick.AddListener(() =>
        {
            if (Content.childCount <= 0)
            {
                Reset();
                return;
            }
            Destroy(Content.GetChild(Content.childCount - 1).gameObject);
            Content.GetChild(Content.childCount - 1).GetComponent<P5PFB>().setVolume();

            r--;
            recordTxt.text = $"Ω计{r}";
        });

        resetBtn.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Reset()
    {
        foreach (var pfb in Content.GetComponentsInChildren<P5PFB>())
            Destroy(pfb.gameObject);

        if (isM1)
        {
            Pon3.setVolume(0);
            Pon5.setVolume(5);
            Pon8.setVolume(3);

            r = 2;
            recordTxt.text = $"Ω计2";
        }else if (isM2)
        {
            Pon3.setVolume(3);
            Pon5.setVolume(0);
            Pon8.setVolume(5);

            r = 2;
            recordTxt.text = $"Ω计2";
        }else if (isP91)
        {
            Pon3.setVolume(0);
            Pon5.setVolume(7);
            Pon8.setVolume(3);

            r = 2;
            recordTxt.text = $"Ω计2";
        }else if (isP92)
        {
            Pon3.setVolume(3);
            Pon5.setVolume(0);
            Pon8.setVolume(7);

            r = 2;
            recordTxt.text = $"Ω计2";
        }else if (isP9)
        {
            Pon3.setVolume(0);
            Pon5.setVolume(0);
            Pon8.setVolume(10);

            r = 1;
            recordTxt.text = $"Ω计1";
        }
        else
        {
            Pon3.setVolume(0);
            Pon5.setVolume(0);
            Pon8.setVolume(8);

            r = 1;
            recordTxt.text = $"Ω计1";
        }
    }

    public void plusRecord()
    {
        r++;
        recordTxt.text = $"Ω计{r}";
        txtPFB.GetComponent<P5PFB>().fillNum(r, Pon8.Volume, Pon5.Volume, Pon3.Volume);
        var obj = Instantiate(txtPFB, Content);
    }
}

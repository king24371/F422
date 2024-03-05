using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P5 : MonoBehaviour
{
    public P5SelectCard Pon8, Pon5, Pon3;

    public Button Record, resetBtn;
    public Button upBtn, downBtn;
    public GameObject recordObj;
    public GameObject txtPFB;
    public GameObject fAnim, Pons;
    public Text recordTxt;
    public Transform Content;
    int r = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitFirst());
        Record.onClick.AddListener(() =>
        {
            recordObj.SetActive(!recordObj.activeSelf);
        });

        upBtn.onClick.AddListener(() =>
        {
            Content.position = new Vector2(Content.position.x, Content.position.y + 99);
        });
        downBtn.onClick.AddListener(() =>
        {
            Content.position = new Vector2(Content.position.x, Content.position.y - 99);
        });

        resetBtn.onClick.AddListener(() =>
        {
            Pon3.setVolume(0);
            Pon5.setVolume(0);
            Pon8.setVolume(8);

            foreach (var pfb in Content.GetComponentsInChildren<P5PFB>())
                Destroy(pfb.gameObject);

            r = 0;
            plusRecord();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void plusRecord()
    {
        r++;
        recordTxt.text = $"¦¸¼Æ¡G{r}";
        txtPFB.GetComponent<P5PFB>().fillNum(r, Pon8.Volume, Pon5.Volume, Pon3.Volume);
        var obj = Instantiate(txtPFB, Content);
    }

    IEnumerator waitFirst()
    {
        yield return new WaitForSeconds(3);
        fAnim.SetActive(false);
        Pons.SetActive(true);
        plusRecord();
    }
}

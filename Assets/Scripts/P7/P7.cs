using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P7 :P3
{
    public Button Round;
    public Transform turnArea;

    // Start is called before the first frame update
    void Start()
    {
        stageBtns._StageClickEvent += StageClick;
        stageBtns.StageChange(0);

        Round.onClick.AddListener(() =>
        {
            if (turnArea.childCount > 0)
            {
                turnArea.GetChild(0).GetComponent<Animator>().enabled = true;
                turnArea.GetChild(0).GetComponent<Animator>().Play(0);
            }
        });
    }

    public override void StageClick(int index)
    {
        for (int i = 0; i < Topics.Count; i++)
        {
            if (i == index)
            {
                Topics[i].gameObject.SetActive(true);
            }
            else
                Topics[i].gameObject.SetActive(false);
        }
    }
}

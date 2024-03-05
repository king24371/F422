using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P10 : P3
{
    void Start()
    {
        stageBtns._StageClickEvent += StageClick;
        stageBtns.StageChange(0);
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

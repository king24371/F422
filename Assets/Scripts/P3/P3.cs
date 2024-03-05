using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3 : MonoBehaviour
{
    [SerializeField]
    protected StageBtns stageBtns;
    public List<GameObject> Topics;

    void Start()
    {
        stageBtns._StageClickEvent += StageClick;
        stageBtns.StageChange(0);
    }

    public virtual void StageClick(int index)
    {
        for (int i = 0; i < Topics.Count; i++)
        {
            if (i == index)
            {
                Topics[i].gameObject.SetActive(true);
                //Topics[i].transform.GetComponent<P3QA>().Reset();
            }
            else
                Topics[i].gameObject.SetActive(false);
        }
    }
}

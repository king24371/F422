using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageBtns : MonoBehaviour
{
    public List<Button> stageBtns = new List<Button>();
    public delegate void StageClickEvent(int index);
    public StageClickEvent _StageClickEvent;
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            stageBtns.Add(transform.GetChild(i).GetComponent<Button>());
        }
        for (int i = 0; i < stageBtns.Count; i++)
        {
            int index = i;
            stageBtns[i].onClick.AddListener(delegate { StageChange(index); });
        }
    }

    public void StageChange(int index)
    {
        for (int i = 0; i < stageBtns.Count; i++)
        {
            stageBtns[i].transform.GetChild(1).gameObject.SetActive(true);
            stageBtns[i].transform.GetChild(2).gameObject.SetActive(false);
        }
        stageBtns[index].transform.GetChild(1).gameObject.SetActive(false);
        stageBtns[index].transform.GetChild(2).gameObject.SetActive(true);

        //點擊按鈕後事件
        if (_StageClickEvent != null)
            _StageClickEvent.Invoke(index);
    }
}

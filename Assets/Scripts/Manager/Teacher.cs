using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teacher : MonoBehaviour
{
    public Image commuFrame;
    public Sprite[] sprs;
    public Button headBtn, nextBtn;

    // Start is called before the first frame update
    void Start()
    {
        headBtn = GetComponent<Button>();
        headBtn.onClick.AddListener(() =>
        {
            if (sprs.Length == 1)
                commuFrame.gameObject.SetActive(!commuFrame.gameObject.activeSelf);
            else
            {
                if (commuFrame.sprite == sprs[sprs.Length - 1])
                {
                    commuFrame.sprite = sprs[0];
                    commuFrame.gameObject.SetActive(false);
                }
                else
                    commuFrame.gameObject.SetActive(true);
            }
        });

        nextBtn.onClick.AddListener(Next);
    }

    void Next()
    {
        int index = 0;

        for(int i = 0; i < sprs.Length; i++)
        {
            if (commuFrame.sprite == sprs[i])
            {
                index = i;
            }
        }

        if (index == sprs.Length-1)
        {
            commuFrame.sprite = sprs[0];
            commuFrame.gameObject.SetActive(false);
        }
        else
        {
            commuFrame.sprite = sprs[index + 1];
        }
    }
}

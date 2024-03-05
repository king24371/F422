using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnScript_OY : MonoBehaviour
{
    public Button m1, m2, m3, C;
    public GameObject m1obj, m2obj, m3obj, methodObj;
    public Sprite[] btnSprs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m1obj.activeSelf)
            m1.image.sprite = btnSprs[1];
        else if(!m1obj.activeSelf)
            m1.image.sprite = btnSprs[0];

        if (m2obj.activeSelf)
            m2.image.sprite = btnSprs[3];
        else if (!m2obj.activeSelf)
            m2.image.sprite = btnSprs[2];

        //if (m3obj.activeSelf)
        //    m3.image.sprite = btnSprs[5];
        //else if (!m1obj.activeSelf)
        //    m3.image.sprite = btnSprs[4];

        //if (methodObj.activeSelf)
        //    C.image.sprite = btnSprs[7];
        //else if (!m1obj.activeSelf)
        //    C.image.sprite = btnSprs[6];
    }
}

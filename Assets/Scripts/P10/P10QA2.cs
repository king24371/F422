using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P10QA2 : MonoBehaviour
{
    public void Reset()
    {
        foreach(var drag in transform.GetComponentsInChildren<UI_Drag>())
        {
            drag.Back();
            drag.transform.localEulerAngles = drag.GetComponent<P10SelectImg>().oriAngle;
        }
        gameObject.SetActive(false);
    }
}

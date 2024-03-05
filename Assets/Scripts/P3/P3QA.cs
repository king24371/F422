using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P3QA : MonoBehaviour
{
    [SerializeField]
    List<UI_Drag> selects = new List<UI_Drag>();
    public Button ResetBtn;

    // Start is called before the first frame update
    void Start()
    {
        ResetBtn.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Reset()
    {
        for (int i = 0; i < selects.Count; i++) selects[i].Back();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnScript : MonoBehaviour
{
    public Button picBtn;
    public GameObject imgObj;
    public Sprite[] btnSprs;

    SpriteState stateBefore = new SpriteState();
    SpriteState stateAfter = new SpriteState();

    // Start is called before the first frame update
    void Start()
    {
        //picBtn.onClick.AddListener(() =>
        //{
        //    imgObj.SetActive(!imgObj.activeSelf);
        //});

        stateBefore.highlightedSprite = btnSprs[2];
        stateAfter.highlightedSprite = btnSprs[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (imgObj.activeSelf)
        {
            picBtn.image.sprite = btnSprs[1];
            picBtn.spriteState = stateAfter;
        }
        else
        {
            picBtn.image.sprite = btnSprs[0];
            picBtn.spriteState = stateBefore;
        }
    }
}

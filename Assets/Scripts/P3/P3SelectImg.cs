using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P3SelectImg : UI_Drag
{
    public float maxX, minX;
    public float maxY, minY;

    //public override 
    public override void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = (eventData.position + offset);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
        print(newPosition);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentTrans);
    }
}

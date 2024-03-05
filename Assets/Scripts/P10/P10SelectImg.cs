using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P10SelectImg : UI_Drag
{
    public float maxX, minX;
    public float maxY, minY;

    public bool isX, isY;
    public bool Test;

    public Vector3 oriAngle;

    private void Start()
    {
        oriAngle = transform.localEulerAngles;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        transform.localEulerAngles = new Vector3(0, 0, 15);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = (eventData.position + offset);

        if (!Test)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        }else
            print(newPosition);

        if (isX)
            transform.position = new Vector2(newPosition.x, transform.position.y);
        else if (isY)
            transform.position = new Vector2(transform.position.x, newPosition.y);
        else
            transform.position = newPosition;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentTrans);
    }
}

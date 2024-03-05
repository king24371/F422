using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    /// <summary>
    /// 原始父物件(Back回歸底下)
    /// </summary>
    protected Transform parentTrans;
    /// <summary>
    /// 原始父物件下的位置
    /// </summary>
    Vector3 orginPos;
    bool canDrag = true;
    public bool CanDrag { get { return canDrag; } set { canDrag = value; } }
    [Header("能不能點擊回到原點")]
    [SerializeField]
    bool cantPoint = false;
    public bool CantPoint { get { return cantPoint; } set { cantPoint = value; } }
    [Header("拖曳要不要複製物件")]
    [SerializeField]
    bool cloneSelf = false;
    /// <summary>
    /// 是否為複製物
    /// </summary>
    bool isClone = false;
    /// <summary>
    /// 複製物
    /// </summary>
    protected GameObject cloneGo;
    /// <summary>
    /// 複製清單
    /// </summary>
    protected List<GameObject> cloneGos = new List<GameObject>();
    [Header("移動物件中心")]
    [SerializeField]
    bool centerMove = true;
    protected Vector2 offset = new Vector2();

    void Awake()
    {
        Init();
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        //如果可以複製
        if (cloneSelf)
        {
            cloneGo = null;
            //複製清單為零時
            if (cloneGos.Count == 0)
            {
                cloneGo = CreateClone();
            }
            else
            {
                //搜尋清單有沒有可用的(隱藏物)
                for (int i = 0; i < cloneGos.Count; i++)
                {
                    if (!cloneGos[i].activeSelf)
                    {
                        cloneGo = cloneGos[i];
                        cloneGo.SetActive(true);
                        break;
                    }
                }
                //沒有可用的 創建
                if (cloneGo == null)
                {
                    cloneGo = CreateClone();
                }
            }
            cloneGo.GetComponent<UI_Drag>().isClone = true;
            if (!centerMove)
                offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        }
        else
        {
            transform.SetParent(parentTrans.parent.parent);
            if (!centerMove)
                offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
        }
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        if (cloneSelf)
        {
            cloneGo.transform.position = eventData.position + offset;
        }
        else
            transform.position = eventData.position + offset;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (!canDrag) return;
        if (cloneSelf)
        {
            List<RaycastResult> hits = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, hits);
            for (int i = 0; i < hits.Count; i++)
            {
                if (hits[i].gameObject.tag == "Target")
                {
                    cloneGo.transform.SetParent(hits[i].gameObject.transform);
                    if(!cantPoint)
                        cloneGo.GetComponent<UI_Drag>().canDrag = false;
                    cloneGo.GetComponent<UI_Drag>().MoveOn();
                    return;
                }
            }
            cloneGo.GetComponent<UI_Drag>().PointerOn();
        }
        else
        {
            List<RaycastResult> hits = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, hits);
            for (int i = 0; i < hits.Count; i++)
            {
                if (hits[i].gameObject.tag == "Target")
                {
                    transform.SetParent(hits[i].gameObject.transform);
                    if (!cantPoint)
                        canDrag = false;
                    MoveOn();
                    return;
                }
            }
            PointerOn();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (canDrag || cantPoint) return;
        PointerOn();
    }

    public virtual void Back()
    {
        if (cloneSelf)
        {
            for (int i = 0; i < cloneGos.Count; i++)
                cloneGos[i].GetComponent<UI_Drag>().Back();
        }
        else
        {
            if (parentTrans == null) return;
            canDrag = true;
            transform.SetParent(parentTrans);
            transform.localPosition = orginPos;
            if (isClone)
                gameObject.SetActive(false);
        }
    }
    public virtual void Init(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
    public void Init()
    {
        parentTrans = transform.parent;
        orginPos = transform.localPosition;
    }
    public virtual void MoveOn()
    {

    }
    public virtual void PointerOn()
    {
        Back();
    }

    public virtual void backPos()
    {
        transform.localPosition = orginPos;
    }

    public GameObject CreateClone()
    {
        GameObject go = Instantiate(gameObject, parentTrans);
        go.GetComponent<UI_Drag>().parentTrans = parentTrans;
        go.GetComponent<UI_Drag>().cloneSelf = false;
        cloneGos.Add(go);
        return go;
    }
}

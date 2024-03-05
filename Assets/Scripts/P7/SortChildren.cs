using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortChildren : MonoBehaviour
{
    private Transform parentTransform;
    private GameObject[] children;
    private int[] initialIndex;

    void Start()
    {
        // 获取父物体的Transform组件
        parentTransform = transform;

        // 获取所有子物体的引用
        int childCount = parentTransform.childCount;
        children = new GameObject[childCount];
        initialIndex = new int[childCount];

        for (int i = 0; i < childCount; i++)
        {
            children[i] = parentTransform.GetChild(i).gameObject;
            initialIndex[i] = children[i].transform.GetSiblingIndex();
        }
    }

    // 当子物体回归到父物体底下时，恢复初始排序
    void Update()
    {
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].transform.IsChildOf(parentTransform))
            {
                ResetOrder();
                break;
            }
        }
    }

    // 恢复初始排序
    void ResetOrder()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].transform.SetSiblingIndex(initialIndex[i]);
        }
    }
}

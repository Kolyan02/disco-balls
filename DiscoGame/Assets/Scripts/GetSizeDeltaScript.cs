using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSizeDeltaScript : MonoBehaviour
{
    private RectTransform rt;
    private float width, heigth;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        width = rt.sizeDelta.x;
        heigth = rt.sizeDelta.y;
        Debug.Log(width);
        Debug.Log(heigth);
    }
}

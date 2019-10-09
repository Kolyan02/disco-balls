using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightUpSript : MonoBehaviour
{
    public MainScript ms;

    void OnTouchDown()
    {
        ms.rightUp = true;
    }
    void OnTouchUp()
    {
        ms.rightUp = false;
    }
    void OnTouchStay()
    {
        ms.rightUp = true;
    }
    void OnTouchExit()
    {
        ms.rightUp = false;
    }
}

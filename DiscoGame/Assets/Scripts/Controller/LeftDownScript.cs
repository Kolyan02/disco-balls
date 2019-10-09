using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDownScript : MonoBehaviour
{
    public MainScript ms;

    void OnTouchDown()
    {
        ms.leftDown = true;
    }
    void OnTouchUp()
    {
        ms.leftDown = false;
    }
    void OnTouchStay()
    {
        ms.leftDown= true;
    }
    void OnTouchExit()
    {
        ms.leftDown = false;
    }
}

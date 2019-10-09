using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDownScript : MonoBehaviour
{
    public MainScript ms;

    void OnTouchDown()
    {
        ms.rightDown = true;
    }
    void OnTouchUp()
    {
        ms.rightDown = false;
    }
    void OnTouchStay()
    {
        ms.rightDown = true;
    }
    void OnTouchExit()
    {
        ms.rightDown = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftUpScript : MonoBehaviour
{
    public MainScript ms;

    void OnTouchDown()
    {
        ms.leftUp = true;
    }
    void OnTouchUp()
    {
        ms.leftUp = false;
    }
    void OnTouchStay()
    {
        ms.leftUp = true;
    }
    void OnTouchExit()
    {
        ms.leftUp = false;
    }
}

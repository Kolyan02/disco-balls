﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, touchInputMask))
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);
                if (Input.GetMouseButtonDown(0))
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                if (Input.GetMouseButtonUp(0))
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                if (Input.GetMouseButton(0))
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
            }
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
#endif

        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();
            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Ended:
                            recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Stationary:
                            recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Moved:
                            recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                            break;
                        case TouchPhase.Canceled:
                            recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                            break;
                    }

                }
            }
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}

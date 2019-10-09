using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineScript : MonoBehaviour
{
    private Animation anim;
    public float shinePeriod;
    private float timer = 2.5f;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= shinePeriod)
        {
            timer = 0.0f;
            anim.Play();
        }
    }

}

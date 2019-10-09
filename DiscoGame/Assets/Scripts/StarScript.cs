using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    private Image s1, s2, s3; //stars
    public void InitializeGO()
    {
        s1 = transform.Find("1").gameObject.GetComponent<Image>();
        s2 = transform.Find("2").gameObject.GetComponent<Image>();
        s3 = transform.Find("3").gameObject.GetComponent<Image>();
    }

    public void UpdateStars(int numOfStars)
    {
        if(numOfStars == 1)
        {
            s1.color = Color.white;
            s2.color = new Color(0, 0, 0, 100.0f / 255);
            s3.color = new Color(0, 0, 0, 100.0f / 255);
        }
        else if(numOfStars == 2)
        {
            s1.color = Color.white;
            s2.color = Color.white;
            s3.color = new Color(0, 0, 0, 100.0f / 255);
        }
        else if(numOfStars == 3)
        {
            s1.color = Color.white;
            s2.color = Color.white;
            s3.color = Color.white;
        }
    }
}

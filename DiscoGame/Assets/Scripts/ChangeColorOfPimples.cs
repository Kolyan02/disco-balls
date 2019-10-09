using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ChangeColorOfPimples : MonoBehaviour
{
    [Header("Right Transform")]
    public Transform[] rightUpT;
    public Transform[] rightRightT;
    public Transform[] rightDownT;
    [Header("Left Transform")]
    public Transform[] leftUpT;
    public Transform[] leftRightT;
    public Transform[] leftDownT;

    [Header("Right Images")]
    public Image[] rightUpImg;
    public Image[] rightRightImg;
    public Image[] rightDownImg;
    [Header("Left Images")]
    public Image[] leftUpImg;
    public Image[] leftRightImg;
    public Image[] leftDownImg;

    private int i, length;

    private void Start()
    {
        length = rightUpImg.Length;
        //ChangePimpleColor(0, Color.cyan); //TEST!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
    public void ChangePimpleColor(int originPoint, Color color)
    {
        Vector2 v = new Vector2(1.7f, 1.7f);
        switch(originPoint)
        {
            case 0:
                for(i = 0; i < length; i++)
                {
                    rightUpT[i].localScale = v;
                    rightUpImg[i].color = color;
                    StartCoroutine(SetToFirstColor(rightUpImg[i], rightUpT[i]));
                }                
                break;
            case 1:
                for (i = 0; i < length; i++)
                {
                    rightRightT[i].localScale = v;
                    rightRightImg[i].color = color;
                    StartCoroutine(SetToFirstColor(rightRightImg[i], rightRightT[i]));
                }
                break;
            case 2:
                for (i = 0; i < length; i++)
                {
                    rightDownT[i].localScale = v;
                    rightDownImg[i].color = color;
                    StartCoroutine(SetToFirstColor(rightDownImg[i], rightDownT[i]));
                }
                break;
            case 3:
                for (i = 0; i < length; i++)
                {
                    leftUpT[i].localScale = v;
                    leftUpImg[i].color = color;
                    StartCoroutine(SetToFirstColor(leftUpImg[i], leftUpT[i]));
                }
                break;
            case 4:
                for (i = 0; i < length; i++)
                {
                    leftRightT[i].localScale = v;
                    leftRightImg[i].color = color;
                    StartCoroutine(SetToFirstColor(leftRightImg[i], leftRightT[i]));
                }
                break;
            case 5:
                for (i = 0; i < length; i++)
                {
                    leftDownT[i].localScale = v;
                    leftDownImg[i].color = color;
                    StartCoroutine(SetToFirstColor(leftDownImg[i], leftDownT[i]));
                }
                break;
        }
    }
    IEnumerator SetToFirstColor(Image img, Transform T)
    {
        yield return new WaitForSeconds(0.23f);
        img.color = Color.white;
        T.localScale = Vector2.one;
    }
}

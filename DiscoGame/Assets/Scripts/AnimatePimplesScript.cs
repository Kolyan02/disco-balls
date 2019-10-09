using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatePimplesScript : MonoBehaviour
{
    [Header("Right")]
    public Animation[] rightUp;
    public Animation[] rightRight;
    public Animation[] rightDown;
    [Header("Left")]
    public Animation[] leftUp;
    public Animation[] leftRight;
    public Animation[] leftDown;
    private int pos = 0, len;

    private void Start()
    {
        InvokeRepeating("AnimatePimples", 0.0f, 0.7f);
        len = rightUp.Length;
    }

    private void AnimatePimples()
    {
        pos++;
        pos %= len;
        //Right
        rightUp[pos].Play();
        rightRight[pos].Play();
        rightDown[pos].Play();
        //Left
        leftUp[pos].Play();
        leftRight[pos].Play();
        leftDown[pos].Play();
    }
}

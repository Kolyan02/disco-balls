using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallAchievementScript : MonoBehaviour
{
    public int Balls
    {
        get
        {
            return balls;
        }
        set
        {            
            balls = value;
            PlayerPrefs.SetInt("balls", balls);
            progressText.text = balls + "/" + targetBalls;
            if (balls >= targetBalls)
            {
                getPrizeButton.enabled = true;
                if(!isShowed)
                {
                    isShowed = true;                    
                    questProgressText.text = progressText.text;
                    questTaskText.text = taskText.text;
                    questAnim.Stop();
                    questAnim.Play();
                }
            }
            else
            {
                getPrizeButton.enabled = false;
            }                    
        }
    }
    private int balls;
    public int targetBalls;
    public int coinsToGet;
    public Text progressText;
    public Button getPrizeButton;
    [Space]
    [Header("Quest Game Object in Game Panel")]    
    public Text questProgressText;
    public Text questTaskText;
    public Animation questAnim;
    [Space]
    [Header("Information about this GO")]    
    public Text taskText;    

    private bool isShowed = false;

    private void Awake()
    {        
        if(PlayerPrefs.HasKey("balls"))
        {
            Balls = PlayerPrefs.GetInt("balls");
        }
        else
        {
            PlayerPrefs.SetInt("balls", 0);
            Balls = 0;
        }        
    }
    public void GetPrize()
    {        
        var info = Camera.main.GetComponent<Info>();
        info.Coins += coinsToGet;
        info.ChangeValueOfBallsBy(-targetBalls);
    }
}

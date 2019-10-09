using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            if(value == 8)
            {
                for(int i = 0; i < 8; i++)
                {
                    hpPieces[i].SetActive(true);
                }
            }
            hp = value;
            if(hp < 8)
            {
                hpPieces[hp].SetActive(false);
            }
            if(hp <= 0)
            {
                hp = 8;
                Time.timeScale = 0;
                if(canShowLosePanel)
                {
                    losePanel.SetActive(true);
                    canShowLosePanel = false;
                }                
                else
                {
                    GoToTheMenuAndHideTheLosePanel();
                }                
            }
        }
    }
    public int Stars
    {
        get
        {
            return stars;
        }
        set
        {
            stars = value;
            numStars.text = stars.ToString();
            PlayerPrefs.SetInt("Stars", value);
        }
    }    
    public int CatchedBalls
    {
        get
        {
            return catchedBalls;
        }
        set
        {
            if(value > catchedBalls)
                ChangeValueOfBallsBy(value - catchedBalls);    
            catchedBalls = value;
            numOfCatchedBalls.text = value.ToString();
        }
    }
    public int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
            coinsText.text = coins.ToString();
            PlayerPrefs.SetInt("coins", coins);
        }
    }
    public int stars = 0;
    public Text numStars;

    public Text numOfCatchedBalls;
    public int catchedBalls = 0;

    private int coins;
    public Text coinsText;

    public int hp = 8;
    public GameObject[] hpPieces;
    public GameObject losePanel;

    public MethodsScript methodsScript;
    public BallAchievementScript[] ballAchievementScripts;

    [HideInInspector]
    public bool canShowLosePanel = true;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("coins"))
        {
            Coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            PlayerPrefs.SetInt("coins", 0);
            Coins = 0;
        }
    }

    private void Start()
    {
        Stars = PlayerPrefs.GetInt("Stars");
    }

    public void HideLosePanelAndContinueTheGame()
    { 
        //WATCH AN ADV!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        HP = 8;
        Time.timeScale = 1;
        losePanel.SetActive(false);
    }

    public void GoToTheMenuAndHideTheLosePanel()
    {
        Time.timeScale = 1;
        losePanel.SetActive(false);
        PlayerPrefs.SetInt("OpenMenu", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
    public void ChangeValueOfBallsBy(int val)
    {
        for (int i = 0; i < ballAchievementScripts.Length; i++)
        {
            ballAchievementScripts[i].Balls += val; // <-delta value of balls
        }
    }
}

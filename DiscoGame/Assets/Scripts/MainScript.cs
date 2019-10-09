using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Status
{
    Prepare, Game, Over
}

public class MainScript : MonoBehaviour
{
    Status s = Status.Prepare;
    private int indexOfHint = 0, i;
    public Info infoScript; //INFO
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameObject ball_1, ball_2;
    public GameObject gamePanel, okButton;
    public float[] coefficients;
    [Header("PrizeStars")]
    public GameObject[] blackStars;
    [Header("GamePanels")]
    public GameObject lvlPanel;
    [Header("Controller")]
    public GameObject leftGather;
    [Header("Controller")]
    public GameObject rightGather;
    public GameObject leftCenter, rightCenter;
    public GameObject[] hints;
    public Mathf f;
    public GameObject[] arrows;
    public GameObject[] points;
    public Transform center;
    public GameObject ball;
    [Header("WIN_PANEL")]
    public GameObject winPanel;
    public GameObject warningPanelStarsAmountIsSmall;
    public string[] key = {"0XX5XX4XX3XX1X0X3X2X123", "0X1321X015241314X21021023", "0XX35X24XX1524X24213322X104XX012103X02X054X5", "02XX351Y443152XX43Y0252Y512", "1Y540Y5XXX32Y44Y1524Y0",
        "1Y545Y24132415Y14XXXXX2515Y241513Y134Y25Y0" };
    private int level = 0, endTime = 0, countY = 0;
    private int[] needStarsToPlayLvl;
    private float coef = 0.7f;
    //State of
    public bool rightUp = false, leftUp = false, rightDown = false, leftDown = false;
    public StarScript[] starScripts;

    Quaternion upRightAngle, downRightAngle, upLeftAngle, downLeftAngle;

    private void Awake()
    {
        int maxLvl = 100;
        needStarsToPlayLvl = new int[maxLvl];
        for(int i = 0; i < maxLvl; i++)
        {
            needStarsToPlayLvl[i] = 3 * i;
        }
        if(!PlayerPrefs.HasKey("Stars"))
        {
            PlayerPrefs.SetInt("Stars", 0);
            for(int i = 1; i <= maxLvl; ++i)
            {
                PlayerPrefs.SetInt("Stars" + i.ToString(), 0);
            }
        }
    }

    private void Start()
    {
        //q45 = Quaternion.Euler(new Vector3(0, 0, 45.0f));
        //q_45 = Quaternion.Euler(new Vector3(0, 0, -45.0f));
        upRightAngle = Quaternion.Euler(new Vector3(0, 0, Vector3.Angle(points[1].transform.position - center.position, points[0].transform.position - center.position)));
        downRightAngle = Quaternion.Euler(new Vector3(0, 0, -Vector3.Angle(points[2].transform.position - center.position, points[1].transform.position - center.position)));
        upLeftAngle = Quaternion.Euler(new Vector3(0, 0, -Vector3.Angle(points[3].transform.position - center.position, points[4].transform.position - center.position)));
        downLeftAngle = Quaternion.Euler(new Vector3(0, 0, Vector3.Angle(points[4].transform.position - center.position, points[5].transform.position - center.position)));
        ApplyColorOfGathers();
        for (i = 0; i < starScripts.Length; ++i)
        {
            starScripts[i].InitializeGO();
        }
        for (i = 1; i <= starScripts.Length; ++i)
        {
            starScripts[i - 1].UpdateStars(PlayerPrefs.GetInt("Stars" + i.ToString()));
        }
    }

    public void ApplyColorOfGathers()
    {
        rightGather.GetComponent<Image>().color = ShopScript.RHS;
        leftGather.GetComponent<Image>().color = ShopScript.LHS;
    }

    public void PlayGame(string lvl)
    {
        infoScript.CatchedBalls = 0;
        s = Status.Game; //for now control will work
        gamePanel.SetActive(true);
        level = int.Parse(lvl); //from string to int
        if (level == 0) //it means, that the game will start as a tutorial
        {
            a(ball_1); a(ball_2);
            a(hints[0]); a(arrows[0]); a(arrows[1]); a(okButton);
        }
        else //a classic game
        {
            //audioSource.PlayOneShot(audioClips[level - 1]);
            if(infoScript.Stars >= needStarsToPlayLvl[level - 1])
            {
                rightCenter.transform.localRotation = Quaternion.identity;
                leftCenter.transform.localRotation = Quaternion.identity;
                coef = coefficients[level - 1];
                countY = 0;
                endTime = 0;
                for (i = 0; i < key[level - 1].Length; i++)
                {
                    if (key[level - 1][i] == 'Y')
                    {
                        endTime--;
                    }
                    else
                    {
                        endTime++;
                    }
                }
                Invoke("WinScreen", endTime * coef + 4.0f);
                for (i = 0; i < key[level - 1].Length; i++)
                {
                    if (key[level - 1][i] == 'Y')
                    {
                        countY++;
                    }
                    else if (key[level - 1][i] != 'X')
                        StartCoroutine(InstantiateBalls(i, countY * 2));
                }
            }
            else
            {
                gamePanel.SetActive(false);
                ShowWarningAmountStarsIsSmall();
            }
        }
    }
    private void ShowWarningAmountStarsIsSmall()
    {
        warningPanelStarsAmountIsSmall.SetActive(true);
        warningPanelStarsAmountIsSmall.GetComponentInChildren<Text>().text = "Тебе следует собрать "
                                                                           + needStarsToPlayLvl[level - 1].ToString()
                                                                           + " звёзд";
        StartCoroutine(HideWarningAmountStarsIsSmall());
    }
    IEnumerator HideWarningAmountStarsIsSmall()
    {
        yield return new WaitForSeconds(2.5f);
        warningPanelStarsAmountIsSmall.SetActive(false);
    }
    IEnumerator InstantiateBalls(int x, int p)
    {
        yield return new WaitForSeconds((x - p) * coef + 2.0f);
        x = (key[level - 1][x] - '0');
        GameObject b = Instantiate(ball, points[x].transform.position, points[x].transform.rotation, points[x].transform) as GameObject;
        b.GetComponent<BallScript>().originPoint = x;
        b.transform.localScale = Vector3.one;
        b.GetComponent<Image>().color = ShopScript.BALL;
    }
    //WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN//
    void WinScreen() //IS NEEDED IN UPDATE!!!!!!!!!!!! WITHOUT RELOADING THE SCENE
    {
        winPanel.SetActive(true);
        infoScript.canShowLosePanel = true;
        if(infoScript.HP >= 7)
        {      
            if(PlayerPrefs.GetInt("Stars" + level.ToString()) < 3)
            {
                infoScript.Stars += (3 - PlayerPrefs.GetInt("Stars" + level.ToString()));
                PlayerPrefs.SetInt("Stars" + level.ToString(), 3);                
            }
            starScripts[level - 1].UpdateStars(PlayerPrefs.GetInt("Stars" + level.ToString()));
            //3 stars
        }
        else if(infoScript.HP >= 4)
        {
            if (PlayerPrefs.GetInt("Stars" + level.ToString()) < 2)
            {
                infoScript.Stars += (2 - PlayerPrefs.GetInt("Stars" + level.ToString()));
                PlayerPrefs.SetInt("Stars" + level.ToString(), 2);
            }
            blackStars[2].SetActive(false);
            starScripts[level - 1].UpdateStars(PlayerPrefs.GetInt("Stars" + level.ToString()));
            //2 stars
        }
        else
        {
            if (PlayerPrefs.GetInt("Stars" + level.ToString()) < 1)
            {
                infoScript.Stars++;
                PlayerPrefs.SetInt("Stars" + level.ToString(), 1);
            }
            blackStars[1].SetActive(false);
            blackStars[2].SetActive(false);
            starScripts[level - 1].UpdateStars(PlayerPrefs.GetInt("Stars" + level.ToString()));
            //1 star
        }
    }
    public void ContinueGame()
    {
        audioSource.Stop();
        infoScript.HP = 8;
        winPanel.SetActive(false);
        gamePanel.SetActive(false);
        lvlPanel.SetActive(true);
        blackStars[1].SetActive(true);
        blackStars[2].SetActive(true);
    }
    //WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN WIN//

    public void NextHint()
    {
        indexOfHint++;
        if (indexOfHint == 4)
        {
            a(hints[3]); a(okButton); a(gamePanel); a(ball_1); a(ball_2);
            indexOfHint = 0;
            s = Status.Prepare;
        }
        else
        {
            if(indexOfHint == 2)
            {
                ball_1.GetComponent<Animation>().Play();
                ball_2.GetComponent<Animation>().Play();
            }
            a(hints[indexOfHint]);
            a(hints[indexOfHint - 1]);
            if (indexOfHint == 1)
                for (i = 0; i < 4; ++i) a(arrows[i]); //hide past & show next arrows
            else if (indexOfHint == 2)
                for (i = 2; i < 4; ++i) a(arrows[i]); //hide arrows |  |
        }                                             //            v  v
    }
    void a(GameObject g) //Set Active
    {
        g.SetActive(!g.activeSelf);
    }
    private void Update()
    {
        if(s == Status.Game)
        {
            if(rightUp)
            {
                rightCenter.transform.localRotation = upRightAngle;
            }
            else if (rightDown)
            {
                rightCenter.transform.localRotation = downRightAngle;
            }
            else
            {
                rightCenter.transform.localRotation = Quaternion.identity;
            }

            if (leftUp)
            {
                leftCenter.transform.localRotation = upLeftAngle;
            }
            else if (leftDown)
            {
                leftCenter.transform.localRotation = downLeftAngle;
            }
            else
            {
                leftCenter.transform.localRotation = Quaternion.identity;
            }
        }
    }
}

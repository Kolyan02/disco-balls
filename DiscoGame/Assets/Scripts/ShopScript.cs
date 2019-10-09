using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public static Color RHS = Color.white, LHS = Color.white, BALL = Color.white;
    public MainScript ms;
    private GameObject prevRHS, prevLHS, prevBALL;
    public GameObject[] GOrhs;
    public GameObject[] GOlhs;
    public GameObject[] GOball;
    private string rhs, lhs, ball;
    private int i;


    private string[] colors = { "RED" , "BLUE" , "DARK_BLUE" , "GREEN" , "PINK" , "WHITE" };


    private void Start()
    {
        prevRHS = GOrhs[5];
        prevLHS = GOlhs[5];
        prevBALL = GOball[5];
        prevRHS.GetComponent<Outline>().enabled = true;
        prevLHS.GetComponent<Outline>().enabled = true;
        prevBALL.GetComponent<Outline>().enabled = true;
    }

    public void GetColorRHS(string color)
    {
        rhs = color;
        for (i = 0; i < GOrhs.Length; ++i)
        {
            if (color == colors[i]) //sought for
            {
                prevRHS.GetComponent<Outline>().enabled = false;
                GOrhs[i].GetComponent<Outline>().enabled = true;
                prevRHS = GOrhs[i];
            }
        }
    }
    public void GetColorLHS(string color)
    {
        lhs = color;
        for (i = 0; i < GOlhs.Length; ++i)
        {
            if (color == colors[i]) //sought for
            {
                prevLHS.GetComponent<Outline>().enabled = false;
                GOlhs[i].GetComponent<Outline>().enabled = true;
                prevLHS = GOlhs[i];
            }
        }
    }
    public void GetColorBALL(string color)
    {
        ball = color;
        for (i = 0; i < GOball.Length; ++i)
        {
            if (color == colors[i]) //sought for
            {
                prevBALL.GetComponent<Outline>().enabled = false;
                GOball[i].GetComponent<Outline>().enabled = true;
                prevBALL = GOball[i];
            }
        }
    }
    public void ApplyColor()
    {
        switch (rhs)
        {
            case "RED":
                RHS = Color.red;
                break;
            case "BLUE":
                RHS = Color.cyan;
                break;
            case "DARK_BLUE":
                RHS = Color.blue;
                break;
            case "GREEN":
                RHS = Color.green;
                break;
            case "PINK":
                RHS = Color.magenta;
                break;
            case "WHITE":
                RHS = Color.white;
                break;
        }
        switch (lhs)
        {
            case "RED":
                LHS = Color.red;
                break;
            case "BLUE":
                LHS = Color.cyan;
                break;
            case "DARK_BLUE":
                LHS = Color.blue;
                break;
            case "GREEN":
                LHS = Color.green;
                break;
            case "PINK":
                LHS = Color.magenta;
                break;
            case "WHITE":
                LHS = Color.white;
                break;
        }
        switch (ball)
        {
            case "RED":
                BALL = Color.red;
                break;
            case "BLUE":
                BALL = Color.cyan;
                break;
            case "DARK_BLUE":
                BALL = Color.blue;
                break;
            case "GREEN":
                BALL = Color.green;
                break;
            case "PINK":
                BALL = Color.magenta;
                break;
            case "WHITE":
                BALL = Color.white;
                break;
        }
        ms.ApplyColorOfGathers();        
    }
}

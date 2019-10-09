using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodsScript : MonoBehaviour
{
    public GameObject settingsPanel, lvlPanel, shopPanel, achievementsPanel;
    public Animation settingsAnimation, shopAnimation, achievementsAnimation;
    public MainScript _mainScript;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("OpenMenu"))
        {
            if(PlayerPrefs.GetInt("OpenMenu") == 1)
            {
                PlayerPrefs.SetInt("OpenMenu", 0);
                OpenMenu();
            }
        }
    }
    public void OpenMenu() //open or close menu panel
    {
        lvlPanel.SetActive(!lvlPanel.activeSelf);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        settingsAnimation.Stop();
        settingsAnimation.Play("OpenPanelAnim");
    }      
    public void OpenShop()
    {
        shopPanel.SetActive(true);
        shopAnimation.Play("OpenPanelAnim");
    }
    public void OpenAchievements()
    {
        achievementsPanel.SetActive(true);
        achievementsAnimation.Play("OpenPanelAnim");
    }
    public void CloseSettings()
    {
        StartCoroutine(YieldCloseSettings());
        settingsAnimation.Stop();
        settingsAnimation.Play("ClosePanelAnim");
    }
    IEnumerator YieldCloseSettings()
    {
        yield return new WaitForSeconds(1.0f);
        settingsPanel.SetActive(false);
    }
    public void CloseShop() 
    {
        StartCoroutine(YieldCloseShop());
        shopAnimation.Stop();
        shopAnimation.Play("ClosePanelAnim");
    }
    IEnumerator YieldCloseShop()
    {
        yield return new WaitForSeconds(1.0f);
        shopPanel.SetActive(false);
    }
    public void CloseAchievements()
    {
        StartCoroutine(YieldCloseAchievements());
        achievementsAnimation.Stop();
        achievementsAnimation.Play("ClosePanelAnim");
    }
    IEnumerator YieldCloseAchievements()
    {
        yield return new WaitForSeconds(1.0f);
        achievementsPanel.SetActive(false);
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_01");
    }
    
    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
    }

    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void ShowCredits()
    {
        HideMainMenu();
        creditsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        creditsPanel.SetActive(false);
        ShowMainMenu();
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
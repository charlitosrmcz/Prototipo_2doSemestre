using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject transition;
    [SerializeField] private GameObject transitionGlitch;
    private Animator AnimationMarco;
    private Animator AnimationGlitch;
    [SerializeField] private GameObject TitleScreen;

    private bool isActive = true;

    private void Start()
    {
        AnimationMarco = transition.GetComponent<Animator>();
        AnimationGlitch = transitionGlitch.GetComponent<Animator>();
    }

    private void Update()
    {
        IntroAnimation();
    }

    private void IntroAnimation()
    {
        if (Input.anyKey && isActive)
        {
            isActive = false;
            AnimationMarco.SetTrigger("Marco2");
            AnimationGlitch.SetTrigger("Glitch");
            TitleScreen.SetActive(false);
            menuPanel.SetActive(true);
        }
    }

    public void LoadMenuScreen()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_01");
    }

    public void OpenOptions()
    {
        
        optionsPanel.SetActive(true);

    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    /*[SerializeField]
    private GameObject winMenu;*/

    [SerializeField]
    private AudioSource backgroundSound;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        int playerScore = player.GetPlayerPoints();

        if (playerScore == 25)
        {
            Win (playerScore);
        }
    }

    private void Win(int playerScore)
    {
        Time.timeScale = 0f;
        /*winMenu.SetActive(true);*/
        SceneManager.LoadScene("Credits");

        backgroundSound.Pause();
        PlayerPrefs.SetInt("score", playerScore);
        PlayerPrefs.Save();
    }
}

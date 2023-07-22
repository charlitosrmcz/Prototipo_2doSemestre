using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostManager : MonoBehaviour
{
    [SerializeField]
    private GameObject lostMenu;

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
        float playerHealth = player.GetPlayerHealth();
        if (playerHealth <= 0)
        {
            Lost();
        }
    }

    void Lost()
    {
        Time.timeScale = 0f;
        lostMenu.SetActive(true);
        backgroundSound.Pause();

        //Saving score
        PlayerPrefs.SetInt("score", player.GetPlayerPoints());
        PlayerPrefs.Save();
    }
}

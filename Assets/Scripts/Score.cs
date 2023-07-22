using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    
    [SerializeField]
    private TMP_Text lastScore;
    // Start is called before the first frame update
    void Start()
    {
        lastScore.text = "Last score: " + PlayerPrefs.GetInt("score", 0);

    }

}

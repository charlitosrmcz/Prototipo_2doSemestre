using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider mySlider;

    [SerializeField]
    private Player personaje;

    public float GetPlayerMaxHealth()
    {
        return personaje.MaxHealth;
    }

    void Start()
    {
        mySlider.maxValue = personaje.MaxHealth;
    }

    void Update()
    {
        mySlider.value = personaje.Health;
    }
}

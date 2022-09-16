using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int health = 100;
    public Text healthText;

    private void Update()
    {
        healthText.text = "Health : " + health;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStamina(float stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }
    public void SetStamina(float stamina)
    {
         slider.value = stamina;
    }
}

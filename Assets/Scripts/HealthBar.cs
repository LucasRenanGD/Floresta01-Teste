
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Image healthBarImage;

    void Awake() => GetComponentInParent<Health>().OnHealthPercentageChanged += HealthChangeEvent;

    void HealthChangeEvent(float healthPercentage)
    {
        healthBarImage.fillAmount = healthPercentage;
    }
}

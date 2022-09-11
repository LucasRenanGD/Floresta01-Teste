using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    public event Action<float> OnHealthPercentageChanged = delegate { };
    public event Action OnHealthReachZero = delegate { };

    void OnEnable() => currentHealth = maxHealth;

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float healthPercentage = (float)currentHealth / (float)maxHealth;
        OnHealthPercentageChanged(healthPercentage);

        if (currentHealth <= 0)
        {
            OnHealthReachZero();
        }

    }

}

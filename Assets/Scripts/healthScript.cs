using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    int currentHealth;

    [SerializeField]
    int maxHealth = 100;
    bool isEnemyDead = false;

    [SerializeField]
    Slider slider;

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;
        if (currentHealth <= 0 && isEnemyDead == false)
        {
            Debug.Log("DEAD" + currentHealth);
            isEnemyDead = true;
            //add deathanimation here:
        }
    }
}

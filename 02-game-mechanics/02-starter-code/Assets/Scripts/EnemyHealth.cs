using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth = 100;
    public float CurrentHealth { 
        get { return currentHealth; } 
        set {
            currentHealth = value;
            if (currentHealth <= 0) { 
                DEATH(); 
            }
        } 
    }
    private float originalXScale;
    public GameObject healthBar;

    private void Start()
    {
        originalXScale = healthBar.transform.localScale.x;
    }

    private void Update()
    {
        // newScale is going to be what we set the scale to. Initially, it's
        // just whatever the current scale is.
        Vector3 newScale = healthBar.transform.localScale;

        newScale.x = (currentHealth / maxHealth) * originalXScale;

        // TODO: Update the x value of newScale. The new value should be a number
        // between 0 and originalXScale based on our currentHealth and maxHealth
        // I.E. if currentHealth is 0, x scale should be 0. If currentHealth
        // == maxHealth, then x scale should be originalXScale.

        healthBar.transform.localScale = newScale;
    }

    private void DEATH()
    {
        GameManager.Instance.Gold += 100;
        Destroy(gameObject);
    }

}

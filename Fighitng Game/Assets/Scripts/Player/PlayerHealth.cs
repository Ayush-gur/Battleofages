using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public int currentHealth;
    public LayerMask otherPlayer;

    public Text healthText;
    public string WhichPlayerText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void DoDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(WhichPlayerText + " Died");
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = WhichPlayerText + " HP: " + currentHealth.ToString();
        }
    }
}

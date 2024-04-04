using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public int currentHealth;

    public Text healthText;
    public string WhichPlayerText;

   
    public GameObject endMenuUI;
    public GameObject endMenuUI2;
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

    private void Die()
    {
        Debug.Log(WhichPlayerText + " Died");
        if (gameObject.tag == "Player 1")
        {
           
            if (!endMenuUI2.activeSelf)
            {
                endMenuUI2.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (gameObject.tag == "Player 2")
        {
           
            if (!endMenuUI.activeSelf)
            {
                endMenuUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = WhichPlayerText + " HP: " + currentHealth.ToString();
        }
    }
}

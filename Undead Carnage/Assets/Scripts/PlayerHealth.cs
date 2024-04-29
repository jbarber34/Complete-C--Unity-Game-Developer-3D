using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText;


    // TODO: Maybe remove so people can't cheat...?
    private void Update()
    {
        DisplayHealth();
        if (Input.GetKeyDown(KeyCode.H) && Input.GetKey(KeyCode.LeftShift))
        {
            hitPoints = hitPoints + 1000f;
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    private void DisplayHealth()
    {
        healthText.text = "Health: " + hitPoints.ToString();
    }

    public void IncreaseHealth(int healthAmount)
    {
        hitPoints += healthAmount;
    }
}

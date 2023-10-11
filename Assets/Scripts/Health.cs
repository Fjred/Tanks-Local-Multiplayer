using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public float health;
    public Transform healthBar;
    public TMP_Text deaths;

    public float deathCount = 0;
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        var player = gameObject.GetComponent<Player>();
        health -= damage;
        if(health <= 0)
        {
            health = maxHealth;

            deathCount ++;
            deaths.text = $"{deathCount}";
            player.crown.enabled = false;
        }
        healthBar.localScale = new Vector3((float)health / maxHealth, 1, 1);
    }
}

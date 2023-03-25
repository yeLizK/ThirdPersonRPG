using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public Image healthBar;
    private int healthAmount;
    private int damage;

    public bool isEnemyAlive;


    private void Start()
    {
        healthAmount = 30;
        damage = 5;
    }
    public void TakeDamage(int damage)
    {
        if(isEnemyAlive)
        {
            if (damage < healthAmount)
            {
                healthAmount -= damage;
            }
            else
            {
                healthAmount = 0;
                Die();
            }
        }
        
    }
    public void Die()
    {
        isEnemyAlive = false;
        StartCoroutine(gameObject.GetComponent<EnemyMovement>().Die());
    }

    public int ReturnDamageAmount()
    {
        return damage;
    }
}

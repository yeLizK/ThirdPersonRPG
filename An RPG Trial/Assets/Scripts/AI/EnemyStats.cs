using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    private Image healthBar;
    private int healthAmount;
    private int damage;
    private bool isTakingDamage;

    public bool isAlive;

    private void Start()
    {
        healthAmount = 100;
        damage = 15;
        isAlive = true;
        healthBar = gameObject.GetComponentInChildren<Image>();
        isTakingDamage = false;
    }
    public IEnumerator TakeDamage(int damage)
    { 
        if(!isTakingDamage)
        {
            if (isAlive)
            {
                isTakingDamage = true;
                if (damage < healthAmount)
                {
                    healthAmount -= damage;
                    healthBar.fillAmount = (float)healthAmount / 100;
                }
                else
                {
                    healthAmount = 0;

                }
                if (healthAmount == 0)
                {
                    healthBar.fillAmount = 0f;
                    Die();
                }
            }

        }
        yield return new WaitForSeconds(2f);
        isTakingDamage = false;

    }
    public void Die()
    {
        isAlive = false;
        StartCoroutine(gameObject.GetComponent<EnemyMovement>().Die());
    }

    public int ReturnDamageAmount()
    {
        return damage;
    }
}

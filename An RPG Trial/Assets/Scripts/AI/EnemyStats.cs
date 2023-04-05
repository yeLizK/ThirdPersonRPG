using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    private Image healthBar;
    private int healthAmount;
    private int damage;

    public bool isAlive;

    private void Start()
    {
        healthAmount = 100;
        damage = 15;
        isAlive = true;
        healthBar = gameObject.GetComponentInChildren<Image>();
    }
    public IEnumerator TakeDamage(int damage)
    {
        if(isAlive)
        {
            if (damage < healthAmount)
            {
                healthAmount -= damage;
                healthBar.fillAmount = (float)healthAmount/100;
            }
            else
            {
                healthAmount = 0;
                
            }
            if(healthAmount == 0)
            {
                healthBar.fillAmount = 0f;
                Die();
            }
        }
        yield return new WaitForSeconds(2f);

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

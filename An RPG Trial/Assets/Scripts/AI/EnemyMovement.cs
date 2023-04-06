using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public FOVDetection FOVDetection;
    public EnemyStats enemyStats;
    public GameObject playerRef;
    public BasicAIMovement BasicAIMovement;
    private NavMeshAgent navMeshAgent;
    private Animator AIAnim;
    private Vector3 initialPosition;

    private float distance;
    private bool isAttacking, isPlayerInMeleeRange;


    private void Start()
    {
        initialPosition = this.transform.position;
        AIAnim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        isAttacking = false;
    }

    private void Update()
    {
        if (enemyStats.isAlive)
        {
            if (FOVDetection.isPlayerDetected)
            {
                AIAnim.SetBool("isOnWatch", false);
                if (Vector3.Distance(transform.position, playerRef.transform.position) < 1.5f)
                {
                    AIAnim.SetBool("isWalking", false);
                    if (!isAttacking)
                    {
                        StartCoroutine(Attack());
                    }
                }
                else
                {
                    Chase();
                }
            }
            else if(!BasicAIMovement.isPatrolling)
            {
                navMeshAgent.destination = initialPosition;
                distance = Vector3.Distance(transform.position, initialPosition);
                if(distance<0.5f)
                {
                    AIAnim.SetBool("isWalking", false);
                    AIAnim.SetBool("isOnWatch", true);
                    transform.LookAt(Vector3.left);
                    return;
                }
                else
                {
                    transform.LookAt(navMeshAgent.destination);

                }
            }
        }
        else
        {
            navMeshAgent.isStopped = true;
        }

    }
    public IEnumerator Die()
    {
        AIAnim.SetBool("isAttacking", false);
        AIAnim.SetBool("isWalking", false);
        AIAnim.SetBool("isOnWatch", false);
        AIAnim.SetBool("Die", true);
        navMeshAgent.destination = transform.position;
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    private void Chase()
    {
        if(enemyStats.isAlive)
        {
            AIAnim.SetBool("isWalking", true);
            navMeshAgent.destination = playerRef.transform.position;
        }
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        AIAnim.SetBool("isAttacking",true);
        if(isPlayerInMeleeRange)
        {
            CharacterManager.Instance.TakeDamage(gameObject.GetComponent<EnemyStats>().ReturnDamageAmount());
        }
        yield return new WaitForSeconds(3f);
        AIAnim.SetBool("isAttacking", false);
        AIAnim.SetBool("isOnWatch",true);
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            isPlayerInMeleeRange = true;
        }
        if(other.gameObject.tag.Equals("Sword"))
        {
            if(CharacterMovement.Instance.isCharAttacking)
            {
                FOVDetection.isPlayerDetected = true;
                AIAnim.SetBool("isWalking", false);
                Chase();
                StartCoroutine(enemyStats.TakeDamage(other.gameObject.GetComponent<Weapon>().damage));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isPlayerInMeleeRange = false;
        }
    }
}

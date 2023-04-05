using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public FOVDetection FOVDetection;
    public EnemyStats enemyStats;
    public GameObject playerRef;
    public List<Transform> TargetPoints;
    private float speed;
    private int targetPointIndex;
    private float distance;
    private bool isPatrolling, isAttacking, isPlayerInMeleeRange;

    private Animator AIAnim;
    private Transform initialPosition;

    private void Start()
    {
        initialPosition = GetComponentInParent<Transform>();
        AIAnim = GetComponent<Animator>();

        targetPointIndex = 0;
        if (TargetPoints.Count > 0)
        {
            transform.LookAt(TargetPoints[targetPointIndex].position);
            isPatrolling = true;
        }
        else isPatrolling = false;
        speed = 1f;
        isAttacking = false;
        enemyStats.isAlive = true;
    }

    private void Update()
    { 
        if(enemyStats.isAlive)
        {
            if (FOVDetection.isPlayerDetected)
            {
                AIAnim.SetBool("isOnWatch", false);
                if (Vector3.Distance(transform.position, playerRef.transform.position) < 1.8f)
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
            else if (isPatrolling)
            {
                distance = Vector3.Distance(transform.position, TargetPoints[targetPointIndex].position);
                if (distance < 1f)
                {
                    StartCoroutine(IncreaseTargetPointIndex());
                }
                else
                {
                    Patrol();
                }
            }
            else
            {
                distance = Vector3.Distance(GetComponentInParent<Transform>().position, initialPosition.position);
                if(distance<0.5f)
                {
                    AIAnim.SetBool("isWalking", false);
                    AIAnim.SetBool("isOnWatch", true);
                    GetComponentInParent<Transform>().forward = initialPosition.forward;
                    return;
                }
                    transform.LookAt(initialPosition);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
    public IEnumerator Die()
    {
        enemyStats.isAlive = false;
        AIAnim.SetBool("isAttacking", false);
        AIAnim.SetBool("isWalking", false);
        AIAnim.SetBool("isOnWatch", false);
        AIAnim.SetBool("Die", true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    private void Chase()
    {
        AIAnim.SetBool("isWalking", true);
        transform.LookAt(playerRef.transform);
        transform.Translate(Vector3.forward * speed * 2f * Time.deltaTime);
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

    private void Patrol()
    {
        AIAnim.SetBool("isWalking", true);
        transform.LookAt(TargetPoints[targetPointIndex].position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
 
    private IEnumerator IncreaseTargetPointIndex()
    {
        isPatrolling = false;
        AIAnim.SetBool("isWalking", false);
        AIAnim.SetBool("isOnWatch", true);
        yield return new WaitForSeconds(2f);
        targetPointIndex++;
        if (targetPointIndex >= TargetPoints.Count)
        {
            targetPointIndex = 0;
        }
        transform.LookAt(TargetPoints[targetPointIndex].position);
        AIAnim.SetBool("isOnWatch", false);
        isPatrolling = true;
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

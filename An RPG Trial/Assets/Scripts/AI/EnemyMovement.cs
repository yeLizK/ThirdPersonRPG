using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> TargetPoints;
    private float speed;
    private int targetPointIndex;
    private float distance;

    private bool isPatrolling, isPlayerDetected, isAttacking,isAlive, isPlayerInMeleeRange;

    public float FOVRadius;
    [Range(0,360)]
    public float FOVAngle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    private Animator AIAnim;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        AIAnim = GetComponent<Animator>();
        StartCoroutine(FOVRoutine());

        targetPointIndex = 0;
        transform.LookAt(TargetPoints[targetPointIndex].position);
        speed = 1f;
        isPatrolling = true;
        isAttacking = false;
        isAlive = true;
    }

    private void Update()
    { 
        if(isAlive)
        {
            if (isPlayerDetected)
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
        }

    }
    public IEnumerator Die()
    {
        AIAnim.SetBool("isAttacking", false);
        AIAnim.SetBool("isWalking", false);
        AIAnim.SetBool("isOnWatch", false);
        AIAnim.SetBool("Die", true);
        yield return new WaitForSeconds(5f);
        isAlive = false;
        gameObject.SetActive(false);

    }
    private void Chase()
    {
        AIAnim.SetBool("isWalking", true);
        transform.LookAt(playerRef.transform);
        transform.Translate(Vector3.forward * speed * 1.5f * Time.deltaTime);
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
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, FOVRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < FOVAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    isPlayerDetected = true;
                }
                else isPlayerDetected = false;
            }
            else { isPlayerDetected = false; }
        }
        else if (isPlayerDetected) isPlayerDetected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            isPlayerInMeleeRange = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> TargetPoints;
    private float speed;
    private int targetPointIndex;
    private float distance;

    private bool isMoving;

    public bool isPlayerDetected;

    public float FOVRadius;
    [Range(0,360)]
    public float FOVAngle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

        targetPointIndex = 0;
        transform.LookAt(TargetPoints[targetPointIndex].position);
        speed = 1f;
        isMoving = true;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, TargetPoints[targetPointIndex].position);
        if(isMoving)
        {
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

    private void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private IEnumerator IncreaseTargetPointIndex()
    {
        isMoving = false;
        yield return new WaitForSeconds(2f);
        targetPointIndex++;
        if (targetPointIndex >= TargetPoints.Count)
        {
            targetPointIndex = 0;
        }
        transform.LookAt(TargetPoints[targetPointIndex].position);
        isMoving = true;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVDetection : MonoBehaviour
{
    public float FOVRadius;
    [Range(0, 360)]public float FOVAngle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool isPlayerDetected;

    public GameObject playerRef;

    private void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    private void LateUpdate()
    {
        if(isPlayerDetected)
        {
            transform.LookAt(playerRef.transform);
        }
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

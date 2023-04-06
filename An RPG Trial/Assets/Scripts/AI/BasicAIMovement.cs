using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAIMovement : MonoBehaviour
{
    public List<Transform> TargetPoints;

    private NavMeshAgent navMeshAgent;
    private Animator AIAnim;
    public Vector3 destination;
    public float waitTime;
    public bool isPatrolling;
    private bool isWaiting;
    private int nextTargetIndex;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        AIAnim = GetComponent<Animator>();
        nextTargetIndex = 0;
        AIAnim.SetBool("isWalking",false);
        if(TargetPoints.Count>0)
        {
            destination = TargetPoints[nextTargetIndex].position;
            isPatrolling = true;
        }

    }
    private void Update()
    {
        if (isPatrolling && !isWaiting)
        {
            destination = TargetPoints[nextTargetIndex].position;
            navMeshAgent.destination = destination;
            AIAnim.SetBool("isWalking", true);
            AIAnim.SetBool("isOnWatch", false);

            if (Vector3.Distance(transform.position, destination) < 1.5f)
            {
                StartCoroutine(AssignNewTarget());
            }
        }
    }

    private IEnumerator AssignNewTarget()
    {
        isWaiting = true;
        AIAnim.SetBool("isWalking", false);
        AIAnim.SetBool("isOnWatch", true);

        yield return new WaitForSeconds(waitTime);
        nextTargetIndex++;
        if (nextTargetIndex >= TargetPoints.Count)
        {
            nextTargetIndex = 0;
        }
        isWaiting = false;

    }
}

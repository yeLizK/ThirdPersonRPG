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
    public float speed;
    private bool isWalking;
    private int nextTargetIndex;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        AIAnim = GetComponent<Animator>();
        nextTargetIndex = 0;
        destination = TargetPoints[nextTargetIndex].position;
        isWalking = true;
    }
    private void Update()
    {
        navMeshAgent.speed = speed;
        AIAnim.SetBool("isWalking", isWalking);
        destination = TargetPoints[nextTargetIndex].position;
        if (isWalking)
        {
            if (Vector3.Distance(transform.position, destination) < 1f)
            {
                StartCoroutine(AssignNewTarget());
            }
        }

        navMeshAgent.destination = destination;

    }

    private IEnumerator AssignNewTarget()
    {
        isWalking = false;
        yield return new WaitForSeconds(waitTime);
        nextTargetIndex++;
        if (nextTargetIndex >= TargetPoints.Count)
        {
            nextTargetIndex = 0;
        }
        isWalking = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
     public NavMeshAgent agent;
    SpriteRenderer sr;
    Animator anim;

   

   // public Transform point1;
    //public Transform point2;

    //private bool isGoingToPoint1 = true;

    public float stoppingDistanceCheck = 0.01f;

    public List<Transform> points;
    public int targetIndex = 0;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }


   
    void Update()
    {
        if(points.Count < 1)
        {
            return;
        }

        if (agent.remainingDistance < stoppingDistanceCheck)

            {
            targetIndex = Random.Range(0, points.Count);

            //for ordered moving between points
           //targetIndex++;
           
            //if (targetIndex >= points.Count)
            //{
            //    targetIndex = 0;
            //}

            }


            agent.SetDestination(points[targetIndex].position);



        //if (point1 == null || point2 == null)



        //    if (agent.velocity.x > 0)
        //    {
        //        sr.flipX = false;
        //    }
        //    else if (agent.velocity.x < 0)
        //    {
        //        sr.flipX = true;
        //    }

        //if (agent.remainingDistance < stoppingDistanceCheck)

        //{
        //    isGoingToPoint1 = !isGoingToPoint1;
        //}

        //if (isGoingToPoint1)
        //{
        //    agent.SetDestination(point1.position);
        //}

        //else
        //{
        //    agent.SetDestination(point2.position);
        //}

        if (agent.velocity.magnitude <= 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
}

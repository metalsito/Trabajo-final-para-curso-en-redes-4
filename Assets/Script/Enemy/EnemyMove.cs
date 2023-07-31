using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyMove : NetworkBehaviour
{

    public Transform[] positionsToPatrol;
    int index = 0;
    public float speed = 4f;
    UnityEngine.AI.NavMeshAgent agent;
    

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        agent.speed = speed;
    }

    private void FixedUpdate()
    {

            if (positionsToPatrol.Length > 0)
            {
                float distanceToThePoint = Vector3.Distance(transform.position, positionsToPatrol[index].position);
                transform.LookAt(positionsToPatrol[index].position);
                //print("Distancia" + distanceToThePoint);
                if (distanceToThePoint > agent.stoppingDistance)
                {
                    //print("Distancia" + distanceToThePoint);
                    agent.destination = positionsToPatrol[index].position;
                }
                else if (index < positionsToPatrol.Length - 1)
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
            }
        
    }
}

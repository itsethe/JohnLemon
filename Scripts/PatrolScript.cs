using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : MonoBehaviour
{
    NavMeshAgent AI;
    public Transform[] waypoints;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
        index = 0;
        AI.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(AI.remainingDistance<AI.stoppingDistance){
            index=(index+1)%waypoints.Length;
            AI.SetDestination(waypoints[index].position);
        }
    }
}

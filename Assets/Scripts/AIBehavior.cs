using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour
{
    public GameObject moveToTarget;
    public GameObject shootingTarget;
    public GameObject projectilePrefab;
    
    private NavMeshAgent navMeshAgent;

    void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(moveToTarget);
    }

    void MoveTo(GameObject target){
        navMeshAgent.destination = target.transform.position;
    }
}

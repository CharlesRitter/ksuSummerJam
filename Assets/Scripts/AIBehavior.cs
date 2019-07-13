using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Lean.Pool;

public class AIBehavior : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem partSys;
    public Transform blowRangeTransform;
    public float rotationSpeed;
    public float blowForce = 50f;
    public bool blowing;


    NavMeshAgent navMeshAgent;
    GameObject player;
    bool inBlowRange;
    bool melting;
    float blowRange = 20f;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        partSys = GetComponentInChildren<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        blowRange = Vector3.Distance(transform.position, blowRangeTransform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (melting)
        {
            //StartMelting();
        }
        else
        {

            if (blowing) FaceTarget(target.transform.position);

            if (GetPlayerDistance() < blowRange)
                StartBlowing();
            else
            {
                if (blowing) StopBlowing();
                MoveTo(player.transform.position);
            }
        }
    }

    void MoveTo(Vector3 target)
    {
        navMeshAgent.destination = target;
    }

    public void StartBlowing()
    {
        blowing = true;
        partSys.Play();
    }

    void StopBlowing()
    {
        blowing = false;
        partSys.Stop();
    }

    void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
    }

    float GetPlayerDistance()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }

    public void Melt()
    {
        melting = true;
    }

}

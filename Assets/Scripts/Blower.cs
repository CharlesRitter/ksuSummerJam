using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour
{
    private AIBehavior aiBehavior;
    private Rigidbody playerRB;
    private GameObject playerGameObject;

    void Awake(){
        aiBehavior = GetComponentInParent<AIBehavior>();
    }

    void OnTriggerStay(Collider other){
        Debug.Log("trigger");
        if(other.gameObject.tag=="Player" && aiBehavior.blowing){
                if(playerRB==null) playerRB = other.GetComponent<Rigidbody>();
                if(playerGameObject==null) playerGameObject = other.gameObject;

                Vector3 direction = playerGameObject.transform.position - aiBehavior.gameObject.transform.position;
                Vector3 force = direction * aiBehavior.blowForce;
                playerRB.AddForce(force);
        }
    }
}

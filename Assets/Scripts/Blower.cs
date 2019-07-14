using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour
{
    private AIBehavior aiBehavior;
    private GameObject playerGameObject;
    CharacterMovement characterMovement;

    void Awake(){
        aiBehavior = GetComponentInParent<AIBehavior>();
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        characterMovement = playerGameObject.GetComponent<CharacterMovement>();
    }

    void OnTriggerStay(Collider other){
        Debug.Log("trigger");
        if(other.gameObject.tag=="Player" && aiBehavior.blowing){
                Vector3 direction = playerGameObject.transform.position - aiBehavior.gameObject.transform.position;
                direction.Normalize(); 
                Vector3 force = direction * aiBehavior.blowForce;

                characterMovement.ApplyForce(force);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            characterMovement.RemoveForce();
        }
    }
}

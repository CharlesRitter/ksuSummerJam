using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject spawn;

    private void Respawn(GameObject RespawnPoint)
    {
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.transform.position = spawn.transform.position;
        gameObject.GetComponent<CharacterController>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Damage")
        {
            Respawn(spawn);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject spawn;

    private void Respawn(GameObject RespawnPoint)
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.transform.position = spawn.transform.position;
        gameObject.GetComponent<CharacterController>().enabled = true;
        gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Damage")
        {
            Respawn(spawn);
        }

    }
}

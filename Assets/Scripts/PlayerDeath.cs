using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Transform spawn;
    public void Respawn()
    {
        gameObject.transform.position = spawn.position;
    }
}

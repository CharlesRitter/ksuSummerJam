using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisions : MonoBehaviour
{
    GameObject collidedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        collidedObject = other.transform.parent.gameObject;
        if(collidedObject.tag == "Damage")
        {
            Debug.Log("ded");
        }
    }
}

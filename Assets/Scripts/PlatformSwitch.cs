﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    bool isActive;

    bool isItActive()
    {
        return (isActive);
    }
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.transform.parent.gameObject;
        if (collidedObject.tag == "SeasonCollider")
        {
            isActive = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject collidedObject = other.transform.parent.gameObject;
        if (collidedObject.tag == "SeasonCollider")
        {
            isActive = true;
        }
    }
}
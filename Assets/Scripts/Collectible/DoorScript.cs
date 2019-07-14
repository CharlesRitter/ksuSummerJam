using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject wk;
    public GameObject sk;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(wk.GetComponent<KeyPickupLogic>().collected && sk.GetComponent<KeyPickupLogic>().collected && transform.position.y > -1f)
        {
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }
    }
}

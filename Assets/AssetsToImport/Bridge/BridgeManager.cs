using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{

    public List<GameObject> vineList;
    // Use this for initialization
    public bool vinesToggle, vinesState, hasBeenUnlocked;
    public float vineTimeOffset;

    public BoxCollider bridge;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vinesToggle)
        {
            if (vinesState)
            {
                foreach (GameObject vine in vineList)
                {
                    vine.GetComponentInChildren<VineAnim>().growth = true;

                }

                bridge.enabled = true;
            }

            else
            {
                foreach (GameObject vine in vineList)
                {
                    vine.GetComponentInChildren<VineAnim>().growth = false;

                }

                bridge.enabled = false;
            }

            vinesState = !vinesState;
            vinesToggle = false;
        }
    }
}
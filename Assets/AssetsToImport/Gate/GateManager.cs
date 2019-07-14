using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{

    public List<GameObject> vineList;
    // Use this for initialization
    public bool vinesToggle, vinesState, hasBeenUnlocked;
    public GameObject padlock;
    public float vineTimeOffset;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vinesToggle)
        {

            if (!hasBeenUnlocked)
            {
                if (padlock.GetComponent<DestroyPadlock>().isDestroyed != true)
                {
                    padlock.GetComponent<DestroyPadlock>().isDestroyed = true;
                    StartCoroutine(OffsetVineAnimation());
                }


                hasBeenUnlocked = true;
            }

            else
            {
                if (vinesState)
                {
                    foreach (GameObject vine in vineList)
                    {
                        vine.GetComponentInChildren<VineAnim>().growth = true;

                    }
                }

                else
                {
                    foreach (GameObject vine in vineList)
                    {
                        vine.GetComponentInChildren<VineAnim>().growth = false;

                    }
                }
            }

            vinesState = !vinesState;
            vinesToggle = false;
        }

        IEnumerator OffsetVineAnimation()
        {
            yield return new WaitForSeconds(vineTimeOffset);
            foreach (GameObject vine in vineList)
            {
                vine.GetComponentInChildren<VineAnim>().growth = false;

            }
            yield return null;
        }
    }
}
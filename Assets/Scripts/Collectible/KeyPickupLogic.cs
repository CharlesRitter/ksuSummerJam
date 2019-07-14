using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupLogic : MonoBehaviour
{
    public enum Keys
    {
        WinterKey,
        SummerKey
    };

    public Keys keyType = Keys.SummerKey;
    public bool collected;
    public bool isCollectible;
    private MeshRenderer selfRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if(keyType == Keys.SummerKey)
        {
            isCollectible = false;
        }
        else
        {
            isCollectible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (keyType == Keys.SummerKey && other.transform.gameObject.tag == "SeasonCollider")
        {
            isCollectible = true;
        }
        else if (isCollectible && other.transform.gameObject.tag == "Player")
        {
            collected = true;
            gameObject.SetActive(false);
        }
        else
        {
            isCollectible = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (keyType == Keys.SummerKey && other.transform.gameObject.tag == "SeasonCollider")
        {
            isCollectible = false;
        }
        else if (keyType == Keys.WinterKey && other.transform.gameObject.tag == "SeasonCollider")
        {
            isCollectible = true;
        }
    }
}

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
    private bool collected;
    private bool isCollectible;
    private MeshRenderer selfRenderer;
    public bool inProximity;
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
        if (keyType == Keys.SummerKey)
        {
            isCollectible = true;
        }
        else
        {
            isCollectible = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (keyType == Keys.SummerKey)
        {
            isCollectible = false;
        }
        else
        {
            isCollectible = true;
        }
    }
}

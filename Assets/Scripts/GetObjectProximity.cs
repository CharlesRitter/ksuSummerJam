using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectProximity : MonoBehaviour
{
    public static bool IsInCircle(GameObject objectInput, GameObject seasonSwitcher)
    {
        Transform parentTransform = objectInput.GetComponent<Transform>();

        if(Vector3.Distance(parentTransform.position, seasonSwitcher.transform.position) <= 3.0f)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }
}

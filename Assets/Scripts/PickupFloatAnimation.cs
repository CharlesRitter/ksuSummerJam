using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFloatAnimation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Mathf.Sin(Time.fixedTime * Mathf.PI) * 0.0025f, 0);
    }
}

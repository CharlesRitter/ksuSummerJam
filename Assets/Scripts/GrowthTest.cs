using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthTest : MonoBehaviour
{
    public GameObject seasonSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetObjectProximity.IsInCircle(transform.gameObject, seasonSwitcher))
        {
            this.transform.localScale += new Vector3(0f, 0.01f, 0f);
        }
        else if(this.transform.localScale.y > 0.2)
        {
            this.transform.localScale += new Vector3(0f, -0.008f, 0f);
        }
    }
}

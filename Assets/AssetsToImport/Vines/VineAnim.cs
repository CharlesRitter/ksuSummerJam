using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineAnim : MonoBehaviour
{
    // Scroll main texture based on time

    public float scrollSpeed = 0.5f;
    Renderer rend;
    public float offset = 0;

    public bool growth;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (growth)
        {
            if (offset < 0.8f)
                offset += Time.deltaTime * scrollSpeed;
            //rend.material.SetTextureOffset("_MainTex", new Vector2(0, Mathf.Clamp(-offset, -1, 0)));
            rend.material.SetFloat("_Growth", Mathf.Clamp((1 - offset), 0, 1));
        }
        else
        {
            if (offset > 0)
                offset -= Time.deltaTime * scrollSpeed;
            //rend.material.SetTextureOffset("_MainTex", new Vector2(0, Mathf.Clamp(-offset, -1, 0)));
            rend.material.SetFloat("_Growth", Mathf.Clamp((1 - offset), 0, 1));
        }

    }
}
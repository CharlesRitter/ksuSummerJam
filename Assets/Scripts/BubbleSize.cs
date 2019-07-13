﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSize : MonoBehaviour
{
    public float radius = 2.5f;

    void Start()
    {
        SetBubbleSize(radius);
    }

    public void SetBubbleSize(float newRadius)
    {
        radius = newRadius;
        transform.localScale = new Vector3(2*radius, 2*radius, 2*radius);
        Shader.SetGlobalFloat("_Radius", radius);
    }

    public void ChangeBubbleSize(float change)
    {
        SetBubbleSize(radius + change);
    }
}

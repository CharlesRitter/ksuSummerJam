using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSize : MonoBehaviour
{
    public float radius = 2.5f;

    private ParticleSystem.MainModule psMain;
    private float baseParticleSize;

    void Start()
    {
        psMain = GetComponentInChildren<ParticleSystem>().main;
        baseParticleSize = psMain.startSize.constant;
        SetBubbleSize(radius);
    }

    public void SetBubbleSize(float newRadius)
    {
        radius = newRadius;
        psMain.startSize = radius * baseParticleSize;
        transform.localScale = new Vector3(2*radius, 2*radius, 2*radius);
        Shader.SetGlobalFloat("_Radius", radius / 2);
    }

    public void ChangeBubbleSize(float change)
    {
        SetBubbleSize(radius + change);
    }
}

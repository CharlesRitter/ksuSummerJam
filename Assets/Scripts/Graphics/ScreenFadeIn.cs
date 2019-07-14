using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeIn : MonoBehaviour
{
    public float fadeTime;
    public float fadeWait;

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine(FadeScreen(fadeTime));
    }
    
    private IEnumerator FadeScreen(float time)
    {
        yield return new WaitForSeconds(fadeWait);
        float current = img.color.a;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            Color col = new Color(img.color.r, img.color.g, img.color.b, Mathf.Lerp(current, 0.0f, t));
            img.color = col;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}

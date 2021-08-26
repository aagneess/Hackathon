using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsiderOut : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;


    public void OutsiderSprite()
    {
        Color c = spriteRenderer.material.color;
        c.a = 0f;
        spriteRenderer.material.color = c;
    }

    IEnumerator FadeOut()
    {
        for (float i = 1; i >= -0.03f; i -= 0.03f)
        {
            Color c = spriteRenderer.material.color;
            c.a = i;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.03f);

        }
    }

    public void FadeOutOutsider()
    {
        StartCoroutine("FadeOut");
    }
}

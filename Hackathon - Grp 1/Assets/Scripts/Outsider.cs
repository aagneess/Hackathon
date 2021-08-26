using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outsider : MonoBehaviour
{
    public AudioSource soundEffectsAudio;
    public Buttons button;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer windowRenderer;
    public GameObject outsiderWalking;
    public GameObject window;

    public void OutsiderSprite()
    {
        Color c = spriteRenderer.material.color;
        c.a = 0f;
        spriteRenderer.material.color = c;
    }

    IEnumerator FadeIn()
    {
        soundEffectsAudio.loop = true;
        soundEffectsAudio.clip = Resources.Load<AudioClip>("Audios/ES_Footsteps_Snow_14_-_SFX_Producer");
        soundEffectsAudio.Play();

        for (float i = 0.05f; i <= 1; i += 0.05f)
        {
            Color c = spriteRenderer.material.color;
            c.a = i;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
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

    IEnumerator WindowSpawn()
    {
        soundEffectsAudio.loop = false;

        soundEffectsAudio.clip = Resources.Load<AudioClip>("Audios/ES_Door_Open_1_-_SFX_Producer");
        soundEffectsAudio.Play();

        window.SetActive(true);

        for (float i = 0.06f; i <= 1; i += 0.06f)
        {
            Color c = windowRenderer.material.color;
            c.a = i;
            windowRenderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void DelayFade()
    {
        StartCoroutine("FadeOut");
    }

    void DelayWindow()
    {
        StartCoroutine("WindowSpawn");
    }

    public void FadeInOutsider()
    {
        outsiderWalking.SetActive(true);
        StartCoroutine("FadeIn");

        Invoke(nameof(DelayFade), 4f);
        Invoke(nameof(DelayWindow), 4.5f);
    }
}

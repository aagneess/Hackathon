using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int clickLevel = 0;
    public AudioSource storyAudio;
    // public StoryQueue storyQueue;
    public state currentState;

    public GameObject ButtonOne;
    public GameObject ButtonTwo;
    public GameObject ButtonTree;

    public GameObject enLiteHandlingText;
    public GameObject medLiteK�rlekText;
    public GameObject bliM�nadsgivareText;
    public GameObject outroBG;

    public Animator textAnimator;

 //   public SpriteRenderer spriteRendererTextOutro;

    public Buttons buttons;

    public bool alreadyPlayed = false;
    bool timerCompleted = false;

    float timer;

    public enum state
    {
        enLitenHandling,
        ljusOchVarme,
        takOverHuvudet,
        kanStillaHunger,
        medLiteKarlek,
        bliManadsGivare
    }

    private void Start()
    {
        currentState = state.enLitenHandling;
    }

    void Update()
    {
        if(currentState == state.enLitenHandling)
        {
            timer += Time.deltaTime;

            if(alreadyPlayed == false && timer > 2f)
            {
                enLiteHandlingText.SetActive(true);
                storyAudio.clip = Resources.Load<AudioClip>("Story/EnLitenHandling");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true && timer > 2f)
            {
                ButtonOne.SetActive(true);
            }
        }

        else if(currentState == state.ljusOchVarme)
        {
            timer = 0f;

            if (alreadyPlayed == false)
            {
                ButtonOne.SetActive(false);

                storyAudio.clip = Resources.Load<AudioClip>("Story/LjusOchV�rme");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true)
            {
                ButtonTwo.SetActive(true);
            }
        }

        else if (currentState == state.takOverHuvudet)
        {
            if (alreadyPlayed == false)
            {
                ButtonTwo.SetActive(false);

                storyAudio.clip = Resources.Load<AudioClip>("Story/Tak�verHuvudet");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true)
            {
                timer += Time.deltaTime;

                if(timer > 3f && timerCompleted == false)
                {
                    timerCompleted = true;
                    timer = 0f;
                    ButtonTree.SetActive(true);
                }
            }
        }

        else if (currentState == state.kanStillaHunger)
        {
            if (alreadyPlayed == false)
            {
                ButtonTree.SetActive(false);

                storyAudio.clip = Resources.Load<AudioClip>("Story/StillaN�gonsHunger");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            timer += Time.deltaTime;

            if (storyAudio.isPlaying != true && timer > 5.8f)
            {
                buttons.stillaN�gonsHungerText.SetActive(false);
                alreadyPlayed = false;
                currentState = state.medLiteKarlek;
            }
        }

        else if (currentState == state.medLiteKarlek)
        {
            timer = 0f;

            if (alreadyPlayed == false)
            {
                storyAudio.clip = Resources.Load<AudioClip>("Story/MedLiteK�rlek");
                storyAudio.PlayDelayed(1f);

                medLiteK�rlekText.SetActive(true);

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true)
            {
                alreadyPlayed = false;
                currentState = state.bliManadsGivare;
            }
        }


        else if (currentState == state.bliManadsGivare)
        {
            if (alreadyPlayed == false)
            {
                timer += Time.deltaTime;

                if(timer >= 1f && timer <= 2f)
                {
                    outroBG.SetActive(true);
                }

                if (timer >= 2f && timer <= 3f)
                {
                    storyAudio.clip = Resources.Load<AudioClip>("Story/Visst_var_det_enkelt");
                    storyAudio.PlayDelayed(0.2f);

                    bliM�nadsgivareText.SetActive(true);
                }

                if (timer > 15f)
                {
                    Debug.Log("quitting");
                    Application.Quit();
                }
            }
        }
    }

/*    IEnumerator FadeInText()
    {
        for (float i = 0.05f; i <= 1; i += 0.05f)
        {
            Color c = spriteRendererTextOutro.material.color;
            c.a = i;
            spriteRendererTextOutro.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }*/
}

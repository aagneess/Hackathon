using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int clickLevel = 0;
    public AudioSource storyAudio;
    // public StoryQueue storyQueue;
    public state currentState;

    public GameObject ButtonOne;
    public GameObject ButtonTwo;
    public GameObject ButtonTree;

    public GameObject medLiteKärlekText;
    public GameObject bliMånadsgivareText;
    public GameObject outroBG;

    public Animator textAnimator;

 //   public SpriteRenderer spriteRendererTextOutro;

    public Buttons buttons;

    public bool alreadyPlayed = false;

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
            if(alreadyPlayed == false)
            {
                storyAudio.clip = Resources.Load<AudioClip>("Story/EnLitenHandling");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true)
            {
                ButtonOne.SetActive(true);
            }
        }

        else if(currentState == state.ljusOchVarme)
        {
            if (alreadyPlayed == false)
            {
                ButtonOne.SetActive(false);

                storyAudio.clip = Resources.Load<AudioClip>("Story/LjusOchVärme");
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

                storyAudio.clip = Resources.Load<AudioClip>("Story/TakÖverHuvudet");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true)
            {
                timer += Time.deltaTime;

                if(timer > 3f)
                {
                    ButtonTree.SetActive(true);
                }
            }
        }

        else if (currentState == state.kanStillaHunger)
        {
            timer = 0f;

            if (alreadyPlayed == false)
            {
                ButtonTree.SetActive(false);

                storyAudio.clip = Resources.Load<AudioClip>("Story/StillaNågonsHunger");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true)
            {
                buttons.stillaNågonsHungerText.SetActive(false);
                alreadyPlayed = false;
                currentState = state.medLiteKarlek;
            }
        }

        else if (currentState == state.medLiteKarlek)
        {
            if (alreadyPlayed == false)
            {
                storyAudio.clip = Resources.Load<AudioClip>("Story/MedLiteKärlek");
                storyAudio.PlayDelayed(1f);

                if(storyAudio.isPlaying == true)
                {
                    medLiteKärlekText.SetActive(true);
                }

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

                    bliMånadsgivareText.SetActive(true);


                    alreadyPlayed = true;
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

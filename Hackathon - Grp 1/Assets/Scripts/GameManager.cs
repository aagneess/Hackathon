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

    public Animator textAnimator;

    public Buttons buttons;

    public bool alreadyPlayed = false;

    float timer;

    public enum state
    {
        enLitenHandling,
        ljusOchVarme,
        takOverHuvudet,
        kanStillaHunger,
        medLiteKarlek
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
                ButtonTree.SetActive(true);
            }
        }

        else if (currentState == state.kanStillaHunger)
        {
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
        }
    }
}

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

    public GameObject medLiteK‰rlekText;

    public Buttons buttons;

    public bool alreadyPlayed = false;

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

                storyAudio.clip = Resources.Load<AudioClip>("Story/LjusOchV‰rme");
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

                storyAudio.clip = Resources.Load<AudioClip>("Story/Tak÷verHuvudet");
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

                storyAudio.clip = Resources.Load<AudioClip>("Story/StillaNÂgonsHunger");
                storyAudio.Play();

                alreadyPlayed = true;
            }

            if (storyAudio.isPlaying != true)
            {
                buttons.stillaNÂgonsHungerText.SetActive(false);
                alreadyPlayed = false;
                currentState = state.medLiteKarlek;
            }
        }

        else if (currentState == state.medLiteKarlek)
        {
            if (alreadyPlayed == false)
            {
                storyAudio.clip = Resources.Load<AudioClip>("Story/MedLiteK‰rlek");
                storyAudio.PlayDelayed(1f);

                if(storyAudio.isPlaying == true)
                {
                    medLiteK‰rlekText.SetActive(true);
                }

                alreadyPlayed = true;
            }
        }
    }
}

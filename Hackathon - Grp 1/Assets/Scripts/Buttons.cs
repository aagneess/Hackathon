using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    //  public SaturationCamera saturationCamera;
    public GameManager gameManager;

    public AudioSource otherAudio;

    public bool spriteActivated = false;
    bool outsiderActivated = false;

    public float timer;

    public GameObject streetLight;
    public GameObject foodCrate;

    public GameObject enLitenHandlingText;
    public GameObject ljusOchVärmeText;
    public GameObject takÖverHuvudetText;
    public GameObject stillaNågonsHungerText;

    public void StreetLightButton()
    {
        if (spriteActivated == false)
        {
            otherAudio.clip = Resources.Load<AudioClip>("Audios/ES_Lamp_Switch_Click_2_-_SFX_Producer");
            otherAudio.Play();
            //  Debug.Log("level " + saturationCamera.saturationLevel);
            //  gameManager.clickLevel++;
            //  saturationCamera.saturationLevel++;
            spriteActivated = true;

            streetLight.SetActive(true);
            ljusOchVärmeText.SetActive(true);
            enLitenHandlingText.SetActive(false);

            spriteActivated = false;
            gameManager.alreadyPlayed = false;
            gameManager.currentState = GameManager.state.ljusOchVarme;
        }
    }

    public void WindowButton()
    {
        if (spriteActivated == false)
        {
            //  Debug.Log("level " + saturationCamera.saturationLevel);
            //  gameManager.clickLevel++;
            //  saturationCamera.saturationLevel++;

            spriteActivated = true;
            outsiderActivated = true;

            takÖverHuvudetText.SetActive(true);
            ljusOchVärmeText.SetActive(false);

            spriteActivated = false;
            gameManager.alreadyPlayed = false;
            gameManager.currentState = GameManager.state.takOverHuvudet;
        }
    }

    public void FoodCrateButton()
    {
        if (spriteActivated == false)
        {
            otherAudio.clip = Resources.Load<AudioClip>("Audios/ES_Crowd_Outdoor_-_SFX_Producer");
            otherAudio.PlayScheduled(3f);

            //  Debug.Log("level " + saturationCamera.saturationLevel);
            //  gameManager.clickLevel++;
            //  saturationCamera.saturationLevel++;

            spriteActivated = true;

            foodCrate.SetActive(true);
            stillaNågonsHungerText.SetActive(true);
            takÖverHuvudetText.SetActive(false);

            spriteActivated = false;
            gameManager.alreadyPlayed = false;
            gameManager.currentState = GameManager.state.kanStillaHunger;
        }
    }
}

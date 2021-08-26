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
    public GameObject ljusOchV‰rmeText;
    public GameObject tak÷verHuvudetText;
    public GameObject stillaNÂgonsHungerText;

    private void Update()
    {
        if(outsiderActivated == true)
        {
            timer += Time.deltaTime;
        }
    }

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
            ljusOchV‰rmeText.SetActive(true);
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

            tak÷verHuvudetText.SetActive(true);
            ljusOchV‰rmeText.SetActive(false);

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
            stillaNÂgonsHungerText.SetActive(true);
            tak÷verHuvudetText.SetActive(false);

            spriteActivated = false;
            gameManager.alreadyPlayed = false;
            gameManager.currentState = GameManager.state.kanStillaHunger;
        }
    }
}

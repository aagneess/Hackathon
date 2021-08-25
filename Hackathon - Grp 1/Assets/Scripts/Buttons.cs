using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    //  public SaturationCamera saturationCamera;
    public GameManager gameManager;

    public bool spriteActivated = false;

    public GameObject streetLight;
    public GameObject windows;
    public GameObject foodCrate;

    public GameObject enLitenHandlingText;
    public GameObject ljusOchV‰rmeText;
    public GameObject tak÷verHuvudetText;
    public GameObject stillaNÂgonsHungerText;

    public void StreetLightButton()
    {
        if (spriteActivated == false)
        {
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

            windows.SetActive(true);
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

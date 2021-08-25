using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
  //  public SaturationCamera saturationCamera;
    public GameManager gameManager;

    bool houseOneActivated = false;
    public GameObject houseOneLightOn;
    public void HouseOneButton()
    {
        houseOneActivated = true;

        if(houseOneActivated == true)
        {
          //  Debug.Log("level " + saturationCamera.saturationLevel);
          //  gameManager.clickLevel++;
          //  saturationCamera.saturationLevel++;
            houseOneLightOn.SetActive(true);
        }
    }
}

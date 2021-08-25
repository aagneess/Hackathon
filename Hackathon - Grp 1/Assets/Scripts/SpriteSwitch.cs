using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    public SaturationCamera saturationCamera;

    bool houseOneActivated = false;
    public GameObject houseOneLightOn;
    public void HouseOneButton()
    {
        houseOneActivated = true;

        if(houseOneActivated == true)
        {
            Debug.Log("level " + saturationCamera.saturationLevel);
            saturationCamera.saturationLevel++;
            houseOneLightOn.SetActive(true);
        }
    }
}

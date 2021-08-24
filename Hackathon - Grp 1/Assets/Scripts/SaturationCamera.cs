using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class SaturationCamera : MonoBehaviour
{
    public int saturationLevel = 0;

    public PostProcessVolume volume;

    void Start()
    {
        volume.weight = 1f;
    }

    void Update()
    {
        if(saturationLevel == 1 && volume.weight > 0.7f)
        {
            Debug.Log(volume.weight);
            ChangeSaturation();
        }
    }

    void ChangeSaturation()
    {
        volume.weight -= 0.2f * Time.deltaTime;
    }
}

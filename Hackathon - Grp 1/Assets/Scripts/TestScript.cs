using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public GameObject testText;
    public void TestButton()
    {
        testText.SetActive(true);
    }
}

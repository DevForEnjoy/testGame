using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOff : MonoBehaviour
{
    public AudioListener audioListener;
    public Text text;
    public void SoundActive() 
    {
        audioListener.enabled = !audioListener.enabled;
        if (audioListener.enabled) text.text = "Sound on";
        else text.text = "Sound off";
    }
    public void SoundActive(bool active)
    {
        audioListener.enabled = active;
    }
}

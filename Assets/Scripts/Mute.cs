using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public GameObject muteImg;
    void Start()
    {
        AudioListener.volume = 1;
        muteImg = GameObject.Find("MuteImg");
        muteImg.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            if(muteImg.activeInHierarchy) muteImg.SetActive(false);
            else muteImg.SetActive(true);
            if(AudioListener.volume == 0) AudioListener.volume = 1;
            else AudioListener.volume = 0;
        }
            
    }
}

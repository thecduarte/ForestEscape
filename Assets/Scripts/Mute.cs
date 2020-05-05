using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    AudioSource backgroundMusic;
    AudioListener audio;
    public GameObject muteImg;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        AudioListener.volume = 1;
        audio = GetComponent<AudioListener>();
        muteImg = GameObject.Find("MuteImg");
        muteImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            if(muteImg.activeInHierarchy) muteImg.SetActive(false);
            else muteImg.SetActive(true);
            // audio.enabled = !audio.enabled;
            if(AudioListener.volume == 0) AudioListener.volume = 1;
            else AudioListener.volume = 0;
        }
            
    }
}

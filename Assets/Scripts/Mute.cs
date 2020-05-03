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
        audio = GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            muteImg.SetActive(!muteImg.activeInHierarchy);
            audio.enabled = !audio.enabled;
            // backgroundMusic.mute = !backgroundMusic.mute;
        }
            
    }
}

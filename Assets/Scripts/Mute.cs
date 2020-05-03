using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    AudioSource backgroundMusic;
    public GameObject muteImg;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
            // muteImg.setActive(true);
            backgroundMusic.mute = !backgroundMusic.mute;
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaintainSound : MonoBehaviour
{
    AudioListener audio;
    GameObject muteImg;
    void Awake(){
        audio = GetComponent<AudioListener>();
        AudioListener.volume = 1;
        muteImg = GameObject.Find("MuteImg");
        muteImg.SetActive(false);
        DontDestroyOnLoad(this.gameObject);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            if(SceneManager.GetActiveScene().buildIndex == 0)
                 if(muteImg.activeInHierarchy) muteImg.SetActive(false);
                 else muteImg.SetActive(true); 
            if(AudioListener.volume == 0) AudioListener.volume = 1;
            else AudioListener.volume = 0;
        }
        if(SceneManager.GetActiveScene().buildIndex == 2) 
            Destroy(this.gameObject);
       
    }
}
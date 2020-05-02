using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadStartMenu", 5f);
    }
    void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
   
}

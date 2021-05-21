using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject buttonContainer;

    void Start()
    {
        buttonContainer.transform.localScale = new Vector3(Screen.height/2960f, Screen.height/2960f, 1f);
    }
    
    public void PlayWithTarget(){
        SceneManager.LoadScene(1);
    }

    public void PlayWithoutTarget(){
        SceneManager.LoadScene(2);
    }

    public void Quit(){
        Application.Quit();
    }

}

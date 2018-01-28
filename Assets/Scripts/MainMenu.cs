using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string FirstLevel;

    public void NewGame()
    {
        SceneManager.LoadScene(FirstLevel);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

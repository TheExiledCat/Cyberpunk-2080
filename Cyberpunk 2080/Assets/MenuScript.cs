using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string sceneToLoad;

    public void loadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public void exitGame()
    {
        Application.Quit();
    }
}


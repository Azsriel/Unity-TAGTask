using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void showInstructions()
    {
        SceneManager.LoadScene(1);
    }

    public void quit1()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void Restart()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

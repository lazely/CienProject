using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.Score = 0;
        SceneManager.LoadScene("Cien Project");
        GameManager.instance.isGameCleared = true;
        GameManager.instance.CurrentStage = -1;
    }
    public void Option()
    {
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif
    }
}

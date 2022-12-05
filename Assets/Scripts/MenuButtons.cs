using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    {
        #if UNITY_EDITOR
          UnityEditor.EditorApplication.isPlaying = false;
        #else
          Application.Quit();
        #endif
    }

}

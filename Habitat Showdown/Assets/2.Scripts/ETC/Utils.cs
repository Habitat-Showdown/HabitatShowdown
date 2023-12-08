using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNames { FLoading = 0, Intro, Lobby, Game}

public class Utils : MonoBehaviour
{
    public static string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static void LoadScene(string sceneName = "")
    {
        if(sceneName == "")
        {
            SceneManager.LoadScene(GetActiveScene());
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public static void LoadScene(SceneNames sceneName)
    {
        // SceneNames 열거형으로 매개변수를 받은 경우 ToString() 처리
        SceneManager.LoadScene((sceneName.ToString()));
    }
}
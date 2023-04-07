using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool GameIsPaused;
    
    public static void UnPause()
    {
        Time.timeScale = 1;
    }

    public static void Pause()
    {
        Time.timeScale = 0;
    }
}

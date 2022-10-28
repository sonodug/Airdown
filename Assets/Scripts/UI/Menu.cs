using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenMenuPanel(GameObject panel)
    {
        panel.SetActive(true);
        PauseControl.GameIsPaused = true;
        PauseControl.PauseGame();
        Debug.Log($"Timescale: {Time.timeScale}");
    }

    public void CloseMenuPanel(GameObject panel)
    {
        panel.SetActive(false);
        PauseControl.GameIsPaused = false;
        PauseControl.PauseGame();
    }

    public void OpenNestedPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void CloseNestedPanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}

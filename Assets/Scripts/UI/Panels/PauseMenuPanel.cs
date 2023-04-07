using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenuPanel : Panel
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _shopButton;

    [SerializeField] private Panel _shopPanel;
    
    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeGame);
        _shopButton.onClick.AddListener(delegate{OpenShopPanel(_shopPanel);});
    }

    public void InitPauseMenuPanel()
    {
        gameObject.SetActive(true);
        PauseControl.GameIsPaused = true;
        PauseControl.Pause();
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    private void ResumeGame()
    {
        gameObject.SetActive(false);
        PauseControl.GameIsPaused = false;
        PauseControl.UnPause();
    }

    private void OpenShopPanel(Panel panel)
    {
        Debug.Log("a");
        gameObject.SetActive(false);
        panel.IsNested = true;
        panel.gameObject.SetActive(true);
    }
}
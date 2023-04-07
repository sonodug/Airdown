using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : Panel
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Panel _pauseMenuPanel;
    
    private void Start()
    {
        _closeButton.onClick.AddListener(ClosePanel);
    }

    public void InitShopPanel()
    {
        gameObject.SetActive(true);
        PauseControl.GameIsPaused = true;
        PauseControl.Pause();
    }
    
    private void ClosePanel()
    {
        if (IsNested)
        {
            _pauseMenuPanel.gameObject.SetActive(true);
            gameObject.SetActive(false);
            IsNested = false;
        }
        else
        {
            gameObject.SetActive(false);
            PauseControl.GameIsPaused = false;
            PauseControl.UnPause();
        }
    }
}
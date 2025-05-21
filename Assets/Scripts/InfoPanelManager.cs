using UnityEngine;

public class InfoPanelManager : MonoBehaviour
{
    public static InfoPanelManager Instance;

    private ShowInfoPanel currentPanel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetActivePanel(ShowInfoPanel panel)
    {
        currentPanel = panel;
    }

    public void ShowCurrentPanel()
    {
        if (currentPanel != null)
            currentPanel.ShowPanel();
    }
}

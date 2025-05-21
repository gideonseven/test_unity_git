using UnityEngine;

public class ShowInfoPanel : MonoBehaviour
{
    public GameObject infoPanel;

    void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    public void ShowPanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);
            InfoPanelManager.Instance?.SetActivePanel(this);
    }

    public void HidePanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}
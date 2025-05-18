using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPanelController : MonoBehaviour
{
    public GameObject instructionsPanel;

    void Start()
    {
        // Hide the panel by default when the app starts
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);
    }

    void OnEnable()
    {
        // Show the panel when the image target is detected
        if (instructionsPanel != null)
            instructionsPanel.SetActive(true);
    }

    void OnDisable()
    {
        // Hide the panel when the image target is lost
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);
    }

    public void ShowPanel()
    {
        // Manually show the panel
        if (instructionsPanel != null)
            instructionsPanel.SetActive(true);
    }

    public void HidePanel()
    {
        // Manually hide the panel - when CloseButton is clicked)
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);
    }
}

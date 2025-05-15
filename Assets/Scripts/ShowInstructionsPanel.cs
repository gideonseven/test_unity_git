using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ShowInstructionsPanel : MonoBehaviour
{
    public GameObject instructionsPanel; 
    void Start()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false); // Initial hiding
    }

    void OnEnable()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(true); // Displayed during image recognition
    }

    void OnDisable()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false); //  disappear during image lost
    }

    // Update is called once per frame
    void Update()
    {

    }
}

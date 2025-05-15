using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class HideInstructionsOnTouch : MonoBehaviour
{
    public GameObject instructionsPanel;
    private bool hasHidden = false;

    void OnEnable()
    {
        LeanTouch.OnFingerTap += HandleTap;
    }

    void OnDisable()
    {
        LeanTouch.OnFingerTap -= HandleTap;
    }

    private void HandleTap(LeanFinger finger)
    {
        if (!hasHidden && instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
            hasHidden = true;
        }
    }
}

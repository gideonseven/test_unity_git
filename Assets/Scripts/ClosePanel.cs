using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    // Assign the UI GameObject that want to hide in the Inspector
    public GameObject viewToClose;

    // Call this function to hide the view
    public void HideView()
    {
        if (viewToClose != null)
        {
            viewToClose.SetActive(false);
        }
    }
}

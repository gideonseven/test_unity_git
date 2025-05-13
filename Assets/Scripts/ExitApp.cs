using UnityEngine;

public class ExitApp : MonoBehaviour
{
    public void ExitGame()
    {
        // Only works on actual device, not in Editor
        Application.Quit();
    }
}

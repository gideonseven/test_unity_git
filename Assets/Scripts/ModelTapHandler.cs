using UnityEngine;

public class TapToShowPanel : MonoBehaviour
{
    public Camera arCamera;
    public ShowInfoPanel showInfoPanel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && showInfoPanel != null)
                {
                    showInfoPanel.ShowPanel();
                }
            }
        }
    }
}

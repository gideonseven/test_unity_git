using UnityEngine;

public class AnchorObjectController : MonoBehaviour
{
    public GameObject arObject;    // Vaso (initially child of ImageTargetMug)
    public Camera arCamera;        // ARCamera from Vuforia
    public float distanceFromCamera = 1.5f; // distance in meters where object will be placed in front of camera
    private bool isMoved = false;

    public void AnchorObjectHere()
    {
        Debug.Log("Move Here button pressed");

        // Calculate target position: in front of camera
        Vector3 targetPosition = arCamera.transform.position + arCamera.transform.forward * distanceFromCamera;

        // Detach from marker if still attached
        arObject.transform.parent = null;

        // Move to target position
        arObject.transform.position = targetPosition;

        isMoved = true;
    }

    void Update()
    {
        if (isMoved && arCamera != null)
        {
            // Optional: Make object always face the camera after moved
            arObject.transform.LookAt(arCamera.transform);
        }
    }
}

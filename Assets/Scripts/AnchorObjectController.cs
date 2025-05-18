using UnityEngine;

public class AnchorObjectController : MonoBehaviour
{
    public Camera arCamera;
    public float distanceFromCamera = 1.5f;

    private GameObject currentARObject;

    // Called by TrackableSwitcher to register which object is currently being tracked
    public void SetCurrentObject(GameObject obj)
    {
        currentARObject = obj;
        Debug.Log("Set current object to: " + obj.name);
    }

    // Called when user presses "Move Here" button
    public void AnchorVisibleObject()
    {
        if (currentARObject == null)
        {
            Debug.LogWarning("No object selected for anchoring.");
            return;
        }

        // Save the current rotation BEFORE unparenting
        Quaternion savedRotation = currentARObject.transform.rotation;

        // Detach from image target
        currentARObject.transform.parent = null;

        // Move to the front of the camera
        Vector3 targetPosition = arCamera.transform.position + arCamera.transform.forward * distanceFromCamera;
        currentARObject.transform.position = targetPosition;

        // Restore original rotation
        currentARObject.transform.rotation = savedRotation;

        Debug.Log("Anchored: " + currentARObject.name + " to " + targetPosition);
    }
}

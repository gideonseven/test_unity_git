using UnityEngine;

public class LockReleaseController : MonoBehaviour
{
    public GameObject arObject;  
    public GameObject imageTarget; 
    private bool isLocked = false;
    private Vector3 lockedPosition;
    private Quaternion lockedRotation;

    public void LockObject()
    {
        if (isLocked) return;

        // Store world position and rotation
        lockedPosition = arObject.transform.position;
        lockedRotation = arObject.transform.rotation;

        // Unparent from ImageTarget
        arObject.transform.parent = null;
        arObject.transform.position = lockedPosition;
        arObject.transform.rotation = lockedRotation;

        isLocked = true;
    }

    public void ReleaseObject()
    {
        if (!isLocked) return;

        // Reparent back to ImageTargetMug
        arObject.transform.SetParent(imageTarget.transform);

        isLocked = false;
    }
}

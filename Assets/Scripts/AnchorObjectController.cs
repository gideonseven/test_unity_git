using UnityEngine;

public class AnchorObjectController : MonoBehaviour
{
    public Camera arCamera;
    public float distanceFromCamera = 1.5f;

    private GameObject currentARObject;

    public void SetCurrentObject(GameObject obj)
    {
        currentARObject = obj;
        Debug.Log("Set current object to: " + obj.name);
    }

    public void AnchorVisibleObject()
    {
        if (currentARObject == null)
        {
            Debug.LogWarning("No object selected for anchoring.");
            return;
        }

        Debug.Log("Anchoring: " + currentARObject.name);

        currentARObject.transform.parent = null;
        Vector3 targetPosition = arCamera.transform.position + arCamera.transform.forward * distanceFromCamera;
        currentARObject.transform.position = targetPosition;
      
    }
}

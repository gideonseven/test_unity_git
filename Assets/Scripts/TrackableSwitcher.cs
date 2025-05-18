using UnityEngine;
using Vuforia;

public class TrackableSwitcher : MonoBehaviour
{
    private GameObject modelObject;
    private ObserverBehaviour observer;

    private static GameObject currentModel;  // Globally tracks the last active model

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        // Auto-assign first child as the model
        if (transform.childCount > 0)
        {
            modelObject = transform.GetChild(0).gameObject;
        }
        else
        {
            Debug.LogError("No 3D model found under " + gameObject.name);
        }

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnDestroy()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (modelObject == null) return;

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            // Deactivate the previous model if different
            if (currentModel != null && currentModel != modelObject)
            {
                currentModel.SetActive(false);
            }

            // Activate this model
            modelObject.SetActive(true);
            currentModel = modelObject;

            // Register it for anchoring
            FindObjectOfType<AnchorObjectController>()?.SetCurrentObject(modelObject);

            Debug.Log("Activated: " + modelObject.name);
        }
        else
        {
            // Hide this model if tracking is lost
            if (modelObject.activeSelf)
            {
                modelObject.SetActive(false);
                Debug.Log("Tracking lost for: " + modelObject.name);
            }
        }
    }
}

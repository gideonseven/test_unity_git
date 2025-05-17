using UnityEngine;
using Vuforia;

public class TrackableSwitcher : MonoBehaviour
{
    private GameObject modelObject;
    private ObserverBehaviour observer;

    private static GameObject currentModel;  // static to track globally

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        // Automatically grab the first child as the model
        if (transform.childCount > 0)
        {
            modelObject = transform.GetChild(0).gameObject;
        }
        else
        {
            Debug.LogError("No model under this ImageTarget: " + gameObject.name);
        }

        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnDestroy()
    {
        if (observer)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (modelObject == null) return;

        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            // Disable the previous model if it exists and isn't this one
            if (currentModel != null && currentModel != modelObject)
            {
                currentModel.SetActive(false);
            }

            modelObject.SetActive(true);
            currentModel = modelObject;

            FindObjectOfType<AnchorObjectController>()?.SetCurrentObject(modelObject);
            Debug.Log("Activated: " + modelObject.name);
        }
        else
        {
            if (modelObject.activeSelf)
            {
                modelObject.SetActive(false);
                Debug.Log("Tracking lost for: " + modelObject.name);
            }
        }
    }
}

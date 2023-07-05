using UnityEngine;

[RequireComponent (typeof(Camera))]
public class AspectRatioController : MonoBehaviour
{

    public Vector2 targetAspect = new Vector2(4, 3);
    private Camera selectedCamera;

    void Awake()
    {
        selectedCamera = GetComponent<Camera>();
        UpdateCrop();
    }

    public void UpdateCrop()
    {
        float screenRatio = Screen.width / (float)Screen.height;
        float targetRatio = targetAspect.x / targetAspect.y;

        if (Mathf.Approximately(screenRatio, targetRatio))
        {
            selectedCamera.rect = new Rect(0, 0, 1, 1);
        }
        else if (screenRatio > targetRatio)
        {
          
            float normalizedWidth = targetRatio / screenRatio;
            float barThickness = (1f - normalizedWidth) / 2f;
            selectedCamera.rect = new Rect(barThickness, 0, normalizedWidth, 1);
        }
        else
        {
           
            float normalizedHeight = screenRatio / targetRatio;
            float barThickness = (1f - normalizedHeight) / 2f;
            selectedCamera.rect = new Rect(0, barThickness, 1, normalizedHeight);
        }
    }
}

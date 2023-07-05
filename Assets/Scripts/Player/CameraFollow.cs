using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 followOffset = new Vector3(0,0,-10);
    public float smoothingValue;
    private Vector3 referenceVel = Vector3.zero;
    private Transform targetPlayer;
    private Vector3 targetPosition;
    void Awake()
    {
    targetPlayer = FindObjectOfType<PlayerController>().transform;    
    }

    void FixedUpdate()
    {
        targetPosition = targetPlayer.position + followOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref referenceVel, smoothingValue);
    }
}

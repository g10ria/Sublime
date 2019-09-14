using UnityEngine;

[ExecuteInEditMode]
public class CameraHandler : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private bool smooth = true;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        } else
        {
            transform.position = desiredPosition;
        }
        
    }
}

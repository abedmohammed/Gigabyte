using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;
    public bool stopFollow;
    private float desiredPositionY;

    private Vector3 smoothedPosition;
    private Vector3 cameraPosition;


    private void FixedUpdate()
    {
        if (!stopFollow)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

    }


}

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private float followSpeed = 10f;

    [SerializeField]
    private float xMin = 0f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position + cameraOffset;
            Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
            Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followSpeed * Time.fixedDeltaTime);

            transform.position = smoothPos;
        }
    }
}
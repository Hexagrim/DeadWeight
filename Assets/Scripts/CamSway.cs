using UnityEngine;

public class CameraSway2D : MonoBehaviour
{
    public float swayAmount = 0.15f;
    public float maxSway = 0.5f;
    public float smoothness = 8f;

    private Vector3 startPos;
    private Vector3 currentVelocity;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float targetX = Mathf.Clamp(-mouseX * swayAmount, -maxSway, maxSway);
        float targetY = Mathf.Clamp(-mouseY * swayAmount, -maxSway, maxSway);
        Vector3 targetPos = startPos + new Vector3(targetX, targetY, 0);
        transform.localPosition = Vector3.SmoothDamp(
            transform.localPosition,
            targetPos,
            ref currentVelocity,
            1f / smoothness
        );
    }
}
using Unity.Cinemachine;
using UnityEditor.Build.Content;
using UnityEngine;

public class MouseCam : MonoBehaviour
{
    public float dragSpeed = 0.01f;
    private Vector3 lastMousePosition;
    public Transform playerTransform;
    public CinemachineCamera Cam;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }


        if (Input.GetMouseButton(1))
        {

            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x, -delta.y, 0) * dragSpeed;
            Cam.transform.Translate(move, Space.Self);
            lastMousePosition = Input.mousePosition;
        }
        else
        {
            transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, playerTransform.position.x, 5 * Time.deltaTime),
            Mathf.Lerp(transform.position.y, playerTransform.position.y, 5 * Time.deltaTime),
            -10f
        );
        }
    }
}
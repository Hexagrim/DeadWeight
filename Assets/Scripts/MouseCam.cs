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
        // this is way too twig like lmao
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
            Cam.transform.position = FindFirstObjectByType<Camera>().transform.position;
        }


        if (Input.GetMouseButton(0))
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
        // this condition makes the cam snap to the curr pos of the cam so it doesnt stay on tghe same area for a few sedconds since the cam thing goes off screen when the camera is staticly stopped y the boundary boxes, did i just write an eaasy here?
        if (Input.GetMouseButtonUp(0))
        {
            Cam.transform.position = FindFirstObjectByType<Camera>().transform.position;
        }
    }
}
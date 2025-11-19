using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;

    [Header("Camera Movement")]
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float zoomSpeed = 5f;

    [Header("Zoom Settings")]
    [SerializeField] private float minZoom = 5f;      // Camera zoom when players are close
    [SerializeField] private float maxZoom = 15f;     // Camera zoom when players are far apart
    [SerializeField] private float zoomLimiter = 10f; // Higher value = slower zoom change based on distance

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        MoveCamera();
        ZoomCamera();
    }

    private void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = new Vector3(centerPoint.x, centerPoint.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }

    private void ZoomCamera()
    {
        float distance = Vector2.Distance(player1.position, player2.position);
        float targetZoom = Mathf.Lerp(minZoom, maxZoom, distance / zoomLimiter);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
    }

    private Vector3 GetCenterPoint()
    {
        return (player1.position + player2.position) / 2f;
    }
}
using UnityEngine;

public class CameraController
{
    
}

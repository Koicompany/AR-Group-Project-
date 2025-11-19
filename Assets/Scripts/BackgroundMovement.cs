using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Transform camera;

    private void Update()
    {
        transform.position = new Vector3(
            camera.position.x,
            camera.position.y,
            transform.position.z
        );
    }
}
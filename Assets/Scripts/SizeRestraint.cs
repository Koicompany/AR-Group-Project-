using UnityEngine;

public class SizeRestraint : MonoBehaviour
{
    private Vector3 originalScale;

    private void Awake()
    {
        // Record the scale the object starts with
        originalScale = transform.localScale;
    }

    private void LateUpdate()
    {
        // Force it to stay the same size every frame
        transform.localScale = originalScale;
    }
}

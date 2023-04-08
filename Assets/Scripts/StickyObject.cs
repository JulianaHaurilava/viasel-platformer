using UnityEngine;

public class StickyObject : MonoBehaviour
{
    public Vector2 offset = new Vector2(0.5f, 0.5f); // смещение объекта от центра экрана
    public Transform target; // объект, за которым закрепляем

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(target.position);
        Vector3 screenPos = new Vector3(
            (viewportPos.x * cam.pixelWidth) - (cam.pixelWidth * 0.5f),
            (viewportPos.y * cam.pixelHeight) - (cam.pixelHeight * 0.5f),
            0
        );
        transform.position = cam.transform.position + screenPos + (Vector3)offset;
    }
}

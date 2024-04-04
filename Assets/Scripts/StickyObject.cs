using UnityEngine;

public class StickyObject : MonoBehaviour
{
    public Vector2 offset = new Vector2(0, 0.7f);

    [SerializeField]
    private Transform target;

    private void LateUpdate()
    {
        transform.position = target.position + (Vector3)offset;
    }
}

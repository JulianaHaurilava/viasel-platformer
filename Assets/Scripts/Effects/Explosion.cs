using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private Transform wheelbarrow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(bomb, wheelbarrow);
            Destroy(this);
        }
    }
}

using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private ScenesManager manager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.SwitchLevel(0);
        }
    }
}

using UnityEngine;

public enum EndResult
{
    DEATH,
    LEVEL_END,
    FINAL_END
}

public class GameEnd : MonoBehaviour
{
    [SerializeField]
    private ScenesManager manager;

    [SerializeField]
    private EndResult endResult;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.EndLevel(endResult);
        }
    }
}

using UnityEngine;

public class CutsceneTriger : MonoBehaviour
{
    [SerializeField] private string cutsceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CutsceneManager.Manager.StartCutscene(cutsceneName);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class CutsceneTriger : MonoBehaviour
{
    [SerializeField]
    private string cutsceneName = "Cutscene_1";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CutsceneManager.Instance.StartCutscene(cutsceneName);
            Destroy(gameObject);
        }
    }
}

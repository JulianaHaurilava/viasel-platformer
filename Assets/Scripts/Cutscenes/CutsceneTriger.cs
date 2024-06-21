using UnityEngine;

public class CutsceneTriger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CutsceneManager.Instance.StartCutscene("Cutscene_1");
            Destroy(gameObject);
        }
    }
}

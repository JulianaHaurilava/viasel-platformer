using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    public static void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

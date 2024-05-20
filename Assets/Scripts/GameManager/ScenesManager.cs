using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private static int _maxLevel;
    private static int levels = 2;

    void Start()
    {
        PlayerData data = SaveSystem.LoadData();
        if (data != null)
        {
            _maxLevel = data.Level;
            return;
        }
        _maxLevel = 1;
    }
    public static void StartGame()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SceneManager.LoadScene(1);
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    public void SwitchLevel(int death)
    {
        switch (death)
        {
            case 0:
                if (SceneManager.GetActiveScene().buildIndex < levels)
                {
                    player.Level++;
                    SaveSystem.SavePlayer(player);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
                break;

            case 1:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            default:
                break;
        }

    }

    public static void LoadLevel()
    {
        SceneManager.LoadScene(_maxLevel);
    }

    public static void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

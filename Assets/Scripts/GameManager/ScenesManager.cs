using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    private static int _maxLevel;
    private static int levels = 3;

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

    public void EndLevel(EndResult endResult)
    {
        switch (endResult)
        {
            case EndResult.LEVEL_END:
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

            case EndResult.DEATH:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            default:
                break;
        }

    }
}

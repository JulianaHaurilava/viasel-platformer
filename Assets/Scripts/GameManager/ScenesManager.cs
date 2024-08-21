using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    [Header("Game Result Panels")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletedPanel;
    [SerializeField] private GameObject winPanel;

    [Space(10)]
    [SerializeField] private Text pointsText;
    [SerializeField] private string maxLevelPoints;

    private static int _maxLevel;

    void Start()
    {
        LoadData();
    }

    /// <summary>
    /// Loads save file
    /// </summary>
    public static void StartGame()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Processes the game end trigger
    /// </summary>
    /// <param name="endResult"></param>
    public void EndLevel(EndResult endResult)
    {
        switch (endResult)
        {
            case EndResult.LEVEL_END:

                player.Level++;
                SaveSystem.SavePlayer(player);
                pointsText.text = $"{player.Points}/{maxLevelPoints}";

                levelCompletedPanel.SetActive(true);
                break;
            case EndResult.DEATH:
                gameOverPanel.SetActive(true);
                break;
            case EndResult.FINAL_END:
                pointsText.text = $"{player.Points}/{maxLevelPoints}";
                winPanel.SetActive(true);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Returns to main menu
    /// </summary>
    public static void MenuEnd()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads last saved level
    /// </summary>
    public static void LoadLevel()
    {
        SceneManager.LoadScene(_maxLevel);
    }

    /// <summary>
    /// Switches to the next level
    /// </summary>
    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Closes the application
    /// </summary>
    public static void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Loads data from save file
    /// </summary>
    private void LoadData()
    {
        PlayerData data = SaveSystem.LoadData();
        if (data != null)
        {
            _maxLevel = data.Level;
            return;
        }
        _maxLevel = 1;
    }
}

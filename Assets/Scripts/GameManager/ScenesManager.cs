using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject loosePanel;

    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private Text pointsText;

    private static int _maxLevel;

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
    public static void MenuEnd()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadLevel()
    {
        SceneManager.LoadScene(_maxLevel);
    }

    public void EndLevel(EndResult endResult)
    {
        switch (endResult)
        {
            case EndResult.LEVEL_END:

                player.Level++;
                SaveSystem.SavePlayer(player);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case EndResult.DEATH:
                loosePanel.SetActive(true);
                break;
            case EndResult.FINAL_END:
                pointsText.text = player.Points.ToString();
                winPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
}

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Stores player data
/// </summary>
public static class SaveSystem
{
    /// <summary>
    /// Saves player data
    /// </summary>
    /// <param name="player"></param>
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/player.txt";
        FileStream stream = new(path, FileMode.Create);

        PlayerData data = new(player);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    /// <summary>
    /// Loads player data
    /// </summary>
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}

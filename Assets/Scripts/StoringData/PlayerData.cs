[System.Serializable]
public class PlayerData
{
    public int Level;
    public int Points;
    public float Health;

    public string[] Items { get; set; }

    public PlayerData(PlayerController player)
    {
        Level = player.Level;
        Points = player.Points;
        Health = player.Health;
        Items = new string[4];

        int i = 0;
        foreach (var item in player.Items)
        {
            Items[i++] = item;
        }
    }
}

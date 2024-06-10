[System.Serializable]
public class PlayerData
{
    public int Level;
    public int Points;
    public float Health;

    public PlayerData(PlayerController player)
    {
        Level = player.Level;
        Points = player.Points;
        Health = player.Health;
    }
}

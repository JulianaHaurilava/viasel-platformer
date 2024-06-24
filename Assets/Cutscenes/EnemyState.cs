using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies = new(); 

    public void SetActiveEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }
}

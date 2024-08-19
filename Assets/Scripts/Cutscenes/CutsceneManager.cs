using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Manager;
    public static GameObject activeCutscene;

    [SerializeField] private PlayerInput player;
    [SerializeField] private List<CutsceneStruct> cutscenes = new();

    private static Dictionary<string, GameObject> _cutsceneDataBase = new();

    private void Awake()
    {
        Manager = this;
        InitializeCutsceneDataBase();
        foreach (var cutscene in _cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }
    }

    private void InitializeCutsceneDataBase()
    {
        _cutsceneDataBase.Clear();
        for (int i = 0; i < cutscenes.Count; i++)
        {
            _cutsceneDataBase.Add(cutscenes[i].cutsceneKey, cutscenes[i].cutsceneObject);
        }
    }

    public void StartCutscene(string cutsceneKey)
    {
        if (!_cutsceneDataBase.ContainsKey(cutsceneKey))
        {
            Debug.Log($"Катсцены c ключом \"{cutsceneKey}\" нет в cutsceneDataBase");
            return;
        }
        if (activeCutscene != null)
        {
            if (activeCutscene == _cutsceneDataBase[cutsceneKey])
            {
                return;
            }
        }
        activeCutscene = _cutsceneDataBase[cutsceneKey];
        foreach (var cutscene in _cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }
        _cutsceneDataBase[cutsceneKey].SetActive(true);

        player.CanMove = false;
    }

    public void EndCutscene()
    {
        if (activeCutscene != null)
        {
            activeCutscene.SetActive(false);
            activeCutscene = null;
            player.CanMove = true;
        }
    }
}

[System.Serializable]
public struct CutsceneStruct
{
    public string cutsceneKey;
    public GameObject cutsceneObject;
}

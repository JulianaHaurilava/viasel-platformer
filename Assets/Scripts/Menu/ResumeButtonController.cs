using Lean.Gui;
using UnityEngine;

public class ResumeButtonController : MonoBehaviour
{
    [SerializeField]
    private LeanButton resumeButton;
    void Start()
    {
        PlayerData data = SaveSystem.LoadData();
        if (data == null)
        {
            resumeButton.interactable = false;
            return;
        }
        resumeButton.interactable = true;
    }
}

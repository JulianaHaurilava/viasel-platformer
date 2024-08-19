using Lean.Gui;
using UnityEngine;

/// <summary>
/// Controlls activity of resume button on main menu
/// </summary>
public class ResumeButtonController : MonoBehaviour
{
    [SerializeField] private GameObject resumeButton;

    void Start()
    {
        SetResumeButton();
    }

    /// <summary>
    /// Checks status and switches interactability of a resume button
    /// </summary>
    private void SetResumeButton()
    {
        PlayerData data = SaveSystem.LoadData();
        if (data == null)
        {
            resumeButton.SetActive(false);
            return;
        }
        resumeButton.SetActive(true);
    }
}

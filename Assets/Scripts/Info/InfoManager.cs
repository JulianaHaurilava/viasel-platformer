using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [Header("Rules Text")]
    [SerializeField] private string[] RULES_TEXT;
    [SerializeField] private string[] TRIGGERS_TEXT;
    [SerializeField] private Text RulesText;

    [Header("Pages")]
    [SerializeField] private GameObject FirstPage;
    [SerializeField] private GameObject LastPage;
    [SerializeField] private GameObject SwitchPage;

    private int _index = -1;

    /// <summary>
    /// Switches to next page
    /// </summary>
    public void ShowNextText()
    {
        int pageNum = _index + 1;

        if (_index == -1)
        {
            FirstPage.SetActive(false);
            SwitchPage.SetActive(true);
            RulesText.text = RULES_TEXT[++_index];
            animator.SetTrigger(TRIGGERS_TEXT[_index]);
        }
        else if (pageNum == RULES_TEXT.Length)
        {
            SwitchPage.SetActive(false);
            LastPage.SetActive(true);
            ++_index;
        }
        else
        {
            RulesText.text = RULES_TEXT[++_index];
            animator.SetTrigger(TRIGGERS_TEXT[_index]);
        }
    }

    /// <summary>
    /// Switches to previous page
    /// </summary>
    public void ShowPreviousText()
    {
        int pageNum = _index - 1;

        if (_index == RULES_TEXT.Length)
        {
            LastPage.SetActive(false);
            SwitchPage.SetActive(true);
            RulesText.text = RULES_TEXT[--_index];
            animator.SetTrigger(TRIGGERS_TEXT[_index]);
        }
        else if (pageNum == -1)
        {
            SwitchPage.SetActive(false);
            FirstPage.SetActive(true);
            --_index;
        }
        else
        {
            RulesText.text = RULES_TEXT[--_index];
            animator.SetTrigger(TRIGGERS_TEXT[_index]);
        }
    }

    public void SetCurrentPageNumberNull()
    {
        _index = -1;

        FirstPage.SetActive(true);
        LastPage.SetActive(false);
        SwitchPage.SetActive(false);
    }
}

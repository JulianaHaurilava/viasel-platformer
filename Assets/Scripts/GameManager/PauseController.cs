using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool _paused = false;

    /// <summary>
    /// Switches pause state
    /// </summary>
    public void ChangeState()
    {
        _paused = !_paused;

        if (_paused)
            Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }
}

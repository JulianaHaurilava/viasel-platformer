using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool paused = false;

    public void ChangeState()
    {
        paused = !paused;

        if (paused)
            Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }
}

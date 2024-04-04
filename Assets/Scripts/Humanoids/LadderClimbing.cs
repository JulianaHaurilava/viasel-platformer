using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    public float ladderSpeed = 0.5f;
    private bool isOnLadder;
    private float verticalInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
        }
    }

    private void Update()
    {
        if (isOnLadder)
        {
            verticalInput = Input.GetAxisRaw("Vertical");

            if (verticalInput > 0f)
            {
                transform.Translate(Vector2.up * ladderSpeed * Time.deltaTime);
            }
            else if (verticalInput < 0f)
            {
                transform.Translate(-Vector2.up * ladderSpeed * Time.deltaTime);
            }
        }
    }
}
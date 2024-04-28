using UnityEngine;

public class Humanoid : MonoBehaviour
{
    [Header("Animation")]
    protected Animator animator;

    [Header("Audio")]
    [SerializeField]
    protected AudioManager audioManager;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
}

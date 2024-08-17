using UnityEngine;

public class Humanoid : MonoBehaviour
{
    [Header("Animation")]
    protected Animator animator;

    [Header("Audio")]
    [SerializeField]
    protected AudioManager audioManager;

    [HideInInspector]
    public Rigidbody2D Rb;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }
}

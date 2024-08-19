using UnityEngine;

public abstract class Humanoid : MonoBehaviour
{
    [HideInInspector] public Animator Animator;
    [SerializeField] protected AudioManager audioManager;
    [HideInInspector] public Rigidbody2D Rb;

    protected virtual void Start()
    {
        Animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }
}

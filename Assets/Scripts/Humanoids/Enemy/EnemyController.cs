using Assets.Scripts.Humanoids.Enemy.States;
using UnityEngine;

public class EnemyController : Mortal
{
    private IEnemyState _currentState;

    [Header("Movement")]
    public float MoveSpeed = 3.0f;
    [SerializeField] public bool FacingRight = true;

    [Header("Player Info")]
    public float TriggerDistance = 10f;

    [SerializeField] private GameObject target;

    [HideInInspector] public Mortal Player;
    [HideInInspector] public float DistanceToPlayer;

    protected override void Start()
    {
        base.Start();
        Animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();

        if (target.TryGetComponent(out Mortal mortal))
        {
            Player = mortal;
        }

        ChangeState(new IdleState());
    }
    protected override void Update()
    {
        base.Update();
        CheckDistance();
    }

    public override void Die()
    {
        base.Die();
        ChangeState(new DeadState());
    }

    /// <summary>
    /// Changes enemy state
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(IEnemyState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter(this);
    }

    /// <summary>
    /// Controlls the distance to player and enemy states
    /// </summary>
    private void CheckDistance()
    {
        DistanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        _currentState?.Execute();
    }
}

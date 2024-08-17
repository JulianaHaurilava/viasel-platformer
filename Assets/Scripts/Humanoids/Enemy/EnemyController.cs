using Assets.Scripts.Humanoids.Enemy.States;
using UnityEngine;

public class EnemyController : Mortal
{
    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private GameObject target;
    private Mortal _player;

    [SerializeField]
    private float triggerDistance;

    [SerializeField]
    private bool facingRight = true;

    private IEnemyState _currentState;
    private IEnemyState _previousState;
    public Animator Animator { get; private set; }
    public float DistanceToPlayer { get; private set; }
    public float TriggerDistance => triggerDistance;
    public Mortal Player => _player;
    public bool FacingRight { get; set; } = true;
    public float MoveSpeed => moveSpeed;

    protected override void Start()
    {
        base.Start();
        Animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();

        if (target.TryGetComponent(out Mortal mortal))
        {
            _player = mortal;
        }

        ChangeState(new IdleState());
    }

    protected override void Update()
    {
        base.Update();

        DistanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        _currentState?.Execute();
    }

    public void ChangeState(IEnemyState newState)
    {
        _previousState = _currentState;
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter(this);
    }

    public override void Die()
    {
        base.Die();
        ChangeState(new DeadState());
    }
}

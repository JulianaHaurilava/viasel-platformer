namespace Assets.Scripts.Humanoids.Enemy.States
{
    public interface IEnemyState
    {
        void Enter(EnemyController enemy);
        void Execute();
        void Exit();
    }
}

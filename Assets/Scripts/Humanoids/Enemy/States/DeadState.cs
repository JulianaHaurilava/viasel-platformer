namespace Assets.Scripts.Humanoids.Enemy.States
{
    public class DeadState : IEnemyState
    {
        public void Enter(EnemyController enemy)
        {
            enemy.enabled = false;
        }
        public void Execute()
        {
        }

        public void Exit()
        {
        }
    }
}

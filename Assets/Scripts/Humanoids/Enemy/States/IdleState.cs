namespace Assets.Scripts.Humanoids.Enemy.States
{
    public class IdleState : IEnemyState
    {
        private EnemyController _enemy;

        public void Enter(EnemyController enemy)
        {
            _enemy = enemy;
        }

        public void Execute()
        {
            if (_enemy.DistanceToPlayer <= _enemy.TriggerDistance)
            {
                _enemy.ChangeState(new ChasingState());
            }
        }

        public void Exit()
        {
        }
    }
}

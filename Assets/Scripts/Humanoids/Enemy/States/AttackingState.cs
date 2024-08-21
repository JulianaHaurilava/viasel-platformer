namespace Assets.Scripts.Humanoids.Enemy.States
{
    public class AttackingState : IEnemyState
    {
        private EnemyController _enemy;

        public void Enter(EnemyController enemy)
        {
            _enemy = enemy;
        }

        public void Execute()
        {
            if (_enemy.DistanceToPlayer > _enemy.AttackRange)
            {
                _enemy.ChangeState(new ChasingState());
            }
            else
            {
                if (_enemy.Player.Health > 0)
                {
                    _enemy.Attack();
                }
            }
        }

        public void Exit()
        {
        }
    }
}

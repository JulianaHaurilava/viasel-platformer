using UnityEngine;

namespace Assets.Scripts.Humanoids.Enemy.States
{
    public class ChasingState : IEnemyState
    {
        private EnemyController _enemy;

        public void Enter(EnemyController enemy)
        {
            _enemy = enemy;
            _enemy.Animator.SetBool("Run", true);
        }

        public void Execute()
        {
            if (_enemy.DistanceToPlayer > _enemy.TriggerDistance)
            {
                _enemy.ChangeState(new IdleState());
            }
            else if (_enemy.DistanceToPlayer <= _enemy.AttackRange)
            {
                _enemy.ChangeState(new AttackingState());
            }
            else
            {
                MoveToPlayer();
            }
        }

        public void Exit()
        {
            _enemy.Animator.SetBool("Run", false);
            _enemy.Rb.velocity = Vector2.zero;
        }

        private void MoveToPlayer()
        {
            Vector2 direction = _enemy.Player.transform.position - _enemy.transform.position;
            if (direction.x < 0 && _enemy.FacingRight)
            {
                Flip(-1);
            }
            else if (direction.x > 0 && !_enemy.FacingRight)
            {
                Flip(1);
            }
            _enemy.Rb.velocity = new Vector2(direction.normalized.x * _enemy.MoveSpeed, _enemy.Rb.velocity.y);
        }

        private void Flip(int k)
        {
            _enemy.FacingRight = !_enemy.FacingRight;
            _enemy.transform.localScale = new Vector3(k * 2, 2, 2);
        }
    }
}

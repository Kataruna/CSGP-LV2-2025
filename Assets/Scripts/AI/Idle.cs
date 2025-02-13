using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.IDLE;
    }

    private float _standingTime = 0f;

    private float _timer;

    public override void Enter()
    {
        _standingTime = Random.Range(1f, 5f);

        base.Enter();
    }

    public override void Update()
    {
        if(_timer <= _standingTime)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            NextState = new Roaming(EnemyClass, Agent);
            Stage = EVENT.EXIT;
        }


        // base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

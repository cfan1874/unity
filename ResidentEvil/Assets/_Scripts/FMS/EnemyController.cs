using UnityEngine;
using System.Collections;

public class EnemyController : EnemyFMS
{
    protected override void Initialize()
    {
        ConstructFSM();
    }
    private void ConstructFSM()
    {


        PatrolState patrol = new PatrolState();
        patrol.AddTransition(Transition.SawPlayer, EnemyStateID.Chasing);
        patrol.AddTransition(Transition.ReachPlayer, EnemyStateID.Attacking);
        patrol.AddTransition(Transition.NoHealth, EnemyStateID.Dead);

        ChaseState chase = new ChaseState();
        chase.AddTransition(Transition.LostPlayer, EnemyStateID.Patrolling);
        chase.AddTransition(Transition.ReachPlayer, EnemyStateID.Attacking);
        chase.AddTransition(Transition.NoHealth, EnemyStateID.Dead);

        AttackState attack = new AttackState();
        attack.AddTransition(Transition.LostPlayer, EnemyStateID.Patrolling);
        attack.AddTransition(Transition.SawPlayer, EnemyStateID.Chasing);
        attack.AddTransition(Transition.NoHealth, EnemyStateID.Dead);


        AddEnemyState(chase);
        AddEnemyState(attack);
        AddEnemyState(patrol);
        

    }
    protected override void FSMUpdate()
    {
    }
    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(playerTransform, transform);
        CurrentState.Act(playerTransform, transform);
    }
    public void SetTransition(Transition t)
    {
        PerformTransition(t);
    }
}

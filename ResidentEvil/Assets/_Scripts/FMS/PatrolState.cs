using UnityEngine;
using System.Collections;

public class PatrolState : EnemyState
{
    public PatrolState()
    {
        StateID = EnemyStateID.Patrolling;
    }

    public override void Reason(Transform player, Transform npc)
    {
        float dist = Vector3.Distance(npc.position, player.position);
        if (dist < 40.0f)
        {
            npc.GetComponent<EnemyController>().SetTransition(Transition.ReachPlayer);
        }
        else if (dist < 100.0f)
        {
            Debug.Log("Switch to Chase State");
            npc.GetComponent<EnemyController>().SetTransition(Transition.SawPlayer);
        }

    }

    public override void Act(Transform player, Transform npc)
    {
        Debug.Log("PatrolState_Act^");
    }
}


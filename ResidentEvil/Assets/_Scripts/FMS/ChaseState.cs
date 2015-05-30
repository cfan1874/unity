using UnityEngine;
using System.Collections;

public class ChaseState : EnemyState
{

    public ChaseState()
    {
        StateID = EnemyStateID.Chasing;
    }

    public override void Reason(Transform player, Transform npc)
    {

        float dist = Vector3.Distance(npc.position, player.position);
        if (dist < 40.0f)
        {
            Debug.Log("ReachPlayer——dist：" + dist);
            npc.GetComponent<EnemyController>().SetTransition(Transition.ReachPlayer);
        }
        else if (dist >= 100.0f)
        {
            Debug.Log("LostPlayer——dist：" + dist);
            npc.GetComponent<EnemyController>().SetTransition(Transition.LostPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        Debug.Log("ChaseState_Act^");
    }
}

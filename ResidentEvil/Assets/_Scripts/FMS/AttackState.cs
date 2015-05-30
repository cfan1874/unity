using UnityEngine;
using System.Collections;

public class AttackState : EnemyState
{
    public AttackState()
    {
        StateID = EnemyStateID.Attacking;
    }

    public override void Reason(Transform player, Transform npc)
    {
        float dist = Vector3.Distance(npc.position, player.position);

        if (dist >= 60.0f && dist < 80.0f)
        {
            Debug.Log("SawPlayer^  dist：" + dist);
            npc.GetComponent<EnemyController>().SetTransition(Transition.SawPlayer);
        }
        else if (dist >= 100.0f)
        {
            Debug.Log("LostPlayer^  dist：" + dist);
            npc.GetComponent<EnemyController>().SetTransition(Transition.LostPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        Debug.Log("AttackState_Act^");
    }
}

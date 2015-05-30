using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 敌人状态切换标识
/// 分别为：空，看见玩家，进入对玩家的可攻击范围，丢失玩家，没有生命值（死亡）
/// </summary>
public enum Transition
{
    None = 0,
    SawPlayer,
    ReachPlayer,
    LostPlayer,
    NoHealth,
}
/// <summary>
/// 敌人状态ID
/// 分别为：空，巡逻，追逐，攻击，死亡
/// </summary>
public enum EnemyStateID
{
    None = 0,
    Patrolling,
    Chasing,
    Attacking,
    Dead,
}
/// <summary>
/// 敌人状态机的实现类
/// </summary>
public class EnemyFMS : FMS
{
    //敌人的状态集合
    private List<EnemyState> enemyStateList;
    //当前状态ID
    protected EnemyStateID CurrentStateID;
    //当前状态
    protected EnemyState CurrentState;
    public EnemyFMS()
    {
        enemyStateList = new List<EnemyState>();
    }

    public void AddEnemyState(EnemyState enemyState)
    {
        if (enemyState == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
            return;
        }

        if (enemyStateList.Count == 0)
        {
            enemyStateList.Add(enemyState);
            CurrentState = enemyState;
            CurrentStateID = enemyState.StateID;
        }

        foreach (EnemyState state in enemyStateList)
        {
            if (state.StateID == enemyState.StateID)
            {
                Debug.LogError("FSM ERROR: Trying to add a state was already inside the list");
                return;
            }
        }

        enemyStateList.Add(enemyState);
    }

    public void DeleteState(EnemyStateID enemyStateID)
    {
        if (enemyStateID == EnemyStateID.None)
        {
            Debug.LogError("FSM ERROR: bull id is not allowed");
            return;
        }
        foreach (EnemyState state in enemyStateList)
        {
            if (state.StateID == enemyStateID)
            {
                enemyStateList.Remove(state);
                return;
            }
        }
    }

    public void PerformTransition(Transition trans)
    {
        if (trans == Transition.None)
        {
            Debug.LogError("FSM ERROR: Null transition is not allowed");
            return;
        }
        //根据状态标识得到状态
        EnemyStateID id = CurrentState.GetOutputState(trans);
        if (id == EnemyStateID.None)
        {
            Debug.LogError("FSM ERROR: Current state does not have a target state for this transition");
            return;
        }

        CurrentStateID = id;
        foreach (EnemyState state in enemyStateList)
        {
            if (state.StateID == CurrentStateID)
            {
                CurrentState = state;
                break;
            }
        }
    }
}

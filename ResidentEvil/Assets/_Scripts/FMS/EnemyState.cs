using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 敌人的状态
/// </summary>
public abstract class EnemyState
{
    //当前状态
    public EnemyStateID StateID;
    //保存状态标识与状态的键值对
    protected Dictionary<Transition, EnemyStateID> dic = new Dictionary<Transition, EnemyStateID>();

    /// <summary>
    /// 状态切换
    /// </summary>
    /// <param name="player"></param>
    /// <param name="npc"></param>
    public abstract void Reason(Transform player, Transform npc);
    /// <summary>
    /// 敌人行为
    /// </summary>
    /// <param name="player"></param>
    /// <param name="npc"></param>
    public abstract void Act(Transform player, Transform npc);
    /// <summary>
    /// 添加状态标识，每个状态标识对应一个状态ID
    /// </summary>
    /// <param name="transition"></param>
    /// <param name="id"></param>
    public void AddTransition(Transition transition, EnemyStateID id)
    {
        if (transition == Transition.None || id == EnemyStateID.None)
        {
            Debug.LogWarning("FSMState ERROR: Null transition not allowed");
            return;
        }

        if (dic.ContainsKey(transition))
        {
            Debug.LogWarning("FSMState ERROR: transition is already inside the map");
            return;
        }
        dic.Add(transition, id);
        Debug.Log("Added: " + transition + " with ID: " + id);
    }
    /// <summary>
    /// 根据状态标识移除状态
    /// </summary>
    /// <param name="trans"></param>
    public void DeleteTransition(Transition trans)
    {
        if (trans == Transition.None)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed");
            return;
        }

        if (dic.ContainsKey(trans))
        {
            dic.Remove(trans);
            return;
        }
        Debug.LogError("FSMState ERROR: Transition passed was not on this state List");
    }
    /// <summary>
    /// 根据状态标识得到状态
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public EnemyStateID GetOutputState(Transition trans)
    {
        if (trans == Transition.None)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed");
            return EnemyStateID.None;
        }

        if (dic.ContainsKey(trans))
        {
            return dic[trans];
        }

        Debug.LogError("FSMState ERROR: " + trans + " Transition passed to the state was not on the list");
        return EnemyStateID.None;

    }

}

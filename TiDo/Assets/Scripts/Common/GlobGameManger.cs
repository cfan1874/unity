using UnityEngine;
using System.Collections;

/// <summary>
/// 枚举：主角的动作类型
/// Idle : 站立
/// Walk:   走路
/// Run:    跑
/// TurnLeft:左转
/// TurnRight：右转
/// ReBack：后退
/// 枚举的值为动画状态下的速度
/// </summary>
public enum PlayerStatus { Idle,Walk,Run,TurnRight,TurnLeft,ReBack }
public class GlobGameManger : MonoBehaviour {
    public static float bgAudioVolume=1f;
    public static float effectAudioVolume=1f;

    public void SetEffectAudioVolume()
    {

    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameAudioManger : MonoBehaviour {

    //播放音效
    public static void EffectAudioPlay(AudioClip effectAudioClip)
    {
        EffectAudioManger.EffectAudioPlay(effectAudioClip);
    }
    //传入音效名称，播放
    public static void EffectAudioPlay(string effectAudioName)
    {
        if (!string.IsNullOrEmpty(effectAudioName))
        {
            EffectAudioManger.EffectAudioPlay(effectAudioName);
        }
    }

    //播放背景音乐
    public static void BgAudioPlay(AudioClip bgAudioClip)
    {
        BgAudioManger.BgAudioPlay(bgAudioClip);
    }
    //传入背景音乐名称，播放音乐
    public static void BgAudioPlay(string bgAudioName)
    {
        if (!string.IsNullOrEmpty(bgAudioName))
        {
            BgAudioManger.BgAudioPlay(bgAudioName);
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectAudioManger : MonoBehaviour
{
    public AudioClip[] audioClipArray;                  //音频源数组
    public static Dictionary<string, AudioClip> audioClipDic;
    public static AudioSource effectAudioSource;
    //改变音效音量大小
    public void SetEffectAudioVolume(float volume)
    {
        GlobGameManger.effectAudioVolume = volume;
        effectAudioSource.volume = volume;
    }
    void Awake()
    {
        audioClipDic = new Dictionary<string, AudioClip>();
        //所有音频放在字典中
        foreach (AudioClip item in audioClipArray)
        {
            audioClipDic.Add(item.name, item);
        }
        //音效的AudioSource
        effectAudioSource = this.GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //播放音效
    public static void EffectAudioPlay(AudioClip effectAudioClip)
    {
        effectAudioSource.clip = effectAudioClip;
        effectAudioSource.volume = GlobGameManger.effectAudioVolume;
        effectAudioSource.loop = false;
        effectAudioSource.Play();
    }
    //传入音效名称，播放
    public static void EffectAudioPlay(string effectAudioName)
    {
        if (!string.IsNullOrEmpty(effectAudioName))
        {
            EffectAudioPlay(audioClipDic[effectAudioName]);
        }
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgAudioManger : MonoBehaviour
{
    public AudioClip[] audioClipArray;                  //音频源数组
    public static Dictionary<string, AudioClip> audioClipDic;
    public static AudioSource bgAudioSource;
    //改变背景音乐大小
    public void SetBgAudioVolume(float volume)
    {
        GlobGameManger.bgAudioVolume = volume;
        bgAudioSource.volume = volume;
    }
    void Awake()
    {
        audioClipDic = new Dictionary<string, AudioClip>();
        //所有音频放在字典中
        foreach (AudioClip item in audioClipArray)
        {
            audioClipDic.Add(item.name, item);
        }
        //得到背景音乐和音效的AudioSource
        bgAudioSource = this.GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start()
    {
        if (audioClipArray.Length > 0)
        {
            //默认播放背景音乐,第一首
            bgAudioSource.clip = audioClipArray[0];
            bgAudioSource.volume = GlobGameManger.bgAudioVolume;
            bgAudioSource.loop = true;
            bgAudioSource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    //播放背景音乐
    public static void BgAudioPlay(AudioClip bgAudioClip)
    {
        //如果重复，则返回
        if (bgAudioSource.clip == bgAudioClip)
        {
            return;
        }
        else
        {
            bgAudioSource.clip = bgAudioClip;
            bgAudioSource.volume = GlobGameManger.bgAudioVolume;
            bgAudioSource.loop = true;
            bgAudioSource.Play();
        }
    }
    //传入背景音乐名称，播放音乐
    public static void BgAudioPlay(string bgAudioName)
    {
        if (!string.IsNullOrEmpty(bgAudioName))
        {
            BgAudioPlay(audioClipDic[bgAudioName]);
        }
    }
}

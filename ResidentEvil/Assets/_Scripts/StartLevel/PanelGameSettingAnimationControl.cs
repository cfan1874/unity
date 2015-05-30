using UnityEngine;
using System.Collections;

public class PanelGameSettingAnimationControl : MonoBehaviour {
    public Animator gameSettingAnimator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GameSettingDown()
    {
        
        gameSettingAnimator.SetBool("gameSettingFlag", true);
        GameAudioManger.EffectAudioPlay("AudioEffect_GUn_Reload");
    }
    public void GameSettingUp()
    {
        
        gameSettingAnimator.SetBool("gameSettingFlag", false);
        GameAudioManger.EffectAudioPlay("AudioEffect_GUn_Reload");
    }
}

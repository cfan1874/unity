using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class T0513 : MonoBehaviour {
    public Text text1;
	// Use this for initialization
	void Start () {
        // EXAMPLE A: initialize with the preferences set in DOTween's Utility Panel
        DOTween.Init();
        // EXAMPLE B: initialize with custom settings, and set capacities immediately
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
        //text1.DOText("This text will replace the existing one", 2).SetEase(Ease.Linear).SetAutoKill(false).Pause();
        //text1.transform.DOMove(new Vector3(-70, 35, 0), 1);
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

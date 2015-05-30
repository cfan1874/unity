using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PanelSliderMoving : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    //初始位置的X
    private float startPosX;
    //移动的X偏移量
    private float moveX;
    //移动Lerp的力度
    public float lerpSize = 2;
    //向左移动的时候，偏移量为负，向右为正
    private string leftOrRight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //print("this.transform.localPosition.x : " + this.transform.localPosition.x);
        //判断
        if (leftOrRight == "right")
        {
            GameAudioManger.EffectAudioPlay("AudioEffect_GunHitMetal");
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x + 800, 0, 0), Time.deltaTime * lerpSize);
            leftOrRight =null;
        }
        else if (leftOrRight =="left")
        {
            GameAudioManger.EffectAudioPlay("AudioEffect_GunHitMetal");
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x - 800, 0, 0), Time.deltaTime * lerpSize);
            leftOrRight = null;
        }
        //左右结尾处无法继续移动
        if (this.transform.localPosition.x > 0)
        {
            this.transform.localPosition =
                Vector3.Lerp(this.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * lerpSize);
        }
        else if (this.transform.localPosition.x < 0)
        {
            this.transform.localPosition =
                Vector3.Lerp(this.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * lerpSize);
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosX=eventData.position.x;

    }

    public void OnDrag(PointerEventData eventData)
    {

        moveX = eventData.position.x - startPosX;
        if (moveX > 0)
        {
            leftOrRight = "right";
        }
        else
        {
            leftOrRight = "left";
        }
       // this.transform.Translate(new Vector3(moveX / 200, 0, 0), Space.World);
    }
}

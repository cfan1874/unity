using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 0.5f;                     //移动速度
    public float rotateSpeed = 1.0f;
    //人物的三个状态 站立、行走、奔跑
    //记录当前人物的状态
    private PlayerStatus gameState;

    //记录鼠标点击的3D坐标点
    private Vector3 point;
    private float time;
    //是否通过键盘控制移动
    private bool isMouseClick = false;
    private float her = 0.0f;
    private float ver = 0.0f;
    void Awake()
    {
        //初始设置人物为站立状态
        SetGameState(PlayerStatus.Idle);
    }

    void Update()
    {
        her = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //按下鼠标左键后
        if (Input.GetMouseButtonDown(0))
        {
            isMouseClick = true;
            MouseLeftClick();
        }
        //键盘移动的时候
        if (Mathf.Abs(her) > 0.1 || Mathf.Abs(ver) > 0.1)
        {
            isMouseClick = false;
            SetGameState(PlayerStatus.Walk);
        }
        else if (!isMouseClick)
        {
            SetGameState(PlayerStatus.Idle);
        }

    }
    /// <summary>
    /// 鼠标左键（地面行走，怪物射击）
    /// </summary>
    void MouseLeftClick()
    {

        //从摄像机的原点向鼠标点击的对象身上设法一条射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //当射线彭转到对象时
        if (Physics.Raycast(ray, out hit))
        {
             //判断当前射线碰撞到的对象是否为敌人
            if (hit.collider.gameObject.tag == "Enemy")
            {
                //得到在3D世界中点击的坐标
                point = hit.point;
                //设置主角面朝这个点，主角的X 与 Z轴不应当发生旋转，
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));

            }
            //判断当前射线碰撞到的对象是否为地形。
            else if (hit.collider.gameObject.tag == "Ground")
            {

                //得到在3D世界中点击的坐标
                point = hit.point;
                //设置主角面朝这个点，主角的X 与 Z轴不应当发生旋转，
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));

                //用户是否连续点击按钮
                if (Time.realtimeSinceStartup - time <= 0.2f)
                {
                    //连续点击 进入奔跑状态
                    SetGameState(PlayerStatus.Run);
                }
                else
                {
                    //点击一次只进入走路状态
                    SetGameState(PlayerStatus.Walk);
                }

                //记录本地点击鼠标的时间
                time = Time.realtimeSinceStartup;
            }
            else
            {
                isMouseClick = false;
            }
        }
    }

    void FixedUpdate()
    {

        switch (gameState)
        {
            case PlayerStatus.Idle:

                break;
            case PlayerStatus.Walk:
                Move(moveSpeed);
                break;

            case PlayerStatus.Run:
                //奔跑时速度加倍
                Move(moveSpeed * 2);
                break;
        }

    }

    void SetGameState(PlayerStatus state)
    {
        switch (state)
        {
            case PlayerStatus.Idle:
                //播放站立动画
                point =  transform.position;
                 //GetComponent<Animation>().Play("Standby");
                 //GetComponent<Animation>().Play("Standing with single fire");
                GetComponent<Animation>().Play("Walk with carbine aimed");
                break;
            case PlayerStatus.Walk:
                //播放行走动画
                // GetComponent<Animation>().Play("Walk");
                GetComponent<Animation>().Play("Walk with carbine aimed");
                break;
            case PlayerStatus.Run:
                //播放奔跑动画
                // GetComponent<Animation>().Play("Run");
                GetComponent<Animation>().Play("Run with carbine aimed");
                break;
        }
        gameState = state;
    }
    /// <summary>
    /// WSAD方向行走，鼠标点击到地面的移动
    /// </summary>
    /// <param name="speed">移动的速度</param>
    void Move(float speed)
    {
        //如果鼠标点击控制行走
        if (isMouseClick)
        {
            //主角没到达目标点时，一直向该点移动
            if (Mathf.Abs(Vector3.Distance(point,  transform.position)) >= 1.3f)
            {
                //得到角色控制器组件
                CharacterController controller =  GetComponent<CharacterController>();
                //限制移动，speed为最大值
                Vector3 v = Vector3.ClampMagnitude(point -  transform.position, speed);
                //可以理解为主角行走或奔跑了一步
                controller.Move(v);
            }
            else
            {
                //到达目标时 继续保持站立状态。
                SetGameState(PlayerStatus.Idle);
                isMouseClick = false;
            }

        }
        //键盘控制移动
        else
        {
            /*
            //旋转
            Vector3 rotateDirection = new Vector3(0, 0, 0);
            //右转
            if (her > 0.1)
            {
                rotateDirection = Vector3.up;
            }
            //左转
            else if (her < -0.1)
            {
                rotateDirection = Vector3.down;
            }

             
             transform.Rotate(rotateDirection * rotateSpeed);
            //得到角色控制器组件
            CharacterController controller =  GetComponent<CharacterController>();
            //注解3 限制移动
            Vector3 v = Vector3.ClampMagnitude(Vector3.forward, speed);
            //向后退
            if (ver < -0.1)
            {
                 v = Vector3.ClampMagnitude(Vector3.back, speed);
            }
            
            //可以理解为主角行走或奔跑了一步
            controller.Move(v);
             */
            //旋转
            Vector3 moveDirection = new Vector3(0, 0, 0);
            //右转
            if (her > 0.1)
            {
                moveDirection = Vector3.up;
            }
            //左转
            else if (her < -0.1)
            {
                moveDirection = Vector3.down;
            }
            
            //得到角色控制器组件
            CharacterController controller = GetComponent<CharacterController>();
            //注解3 限制移动
            Vector3 v = Vector3.ClampMagnitude(transform.forward, speed);
            //向后退,后退的时候不左右移动
            if (ver < -0.1)
            {
                v = Vector3.ClampMagnitude(-transform.forward, speed);
                //可以理解为主角行走或奔跑了一步
                controller.Move(v);
            }
            else
            {
                transform.Rotate(moveDirection * rotateSpeed);
                controller.Move(v);
            }
            
        }
    }
}

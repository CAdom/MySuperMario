using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
   //public static int Hp.PlayerHp;//血量
    float f;//移动方向
    Animator ani;//玩家动画
    SpriteRenderer spr;//玩家精灵
    Rigidbody2D rig;//刚体
    bool isGround;//玩家是否在地面上
    RaycastHit2D dhit;//玩家发射的向下的射线所碰到的物体信息
    RaycastHit2D hit;//玩家向左或者右侧发射射线所碰到的物体信息
    public float aaa;
    public static string wanjia; //玩家状态
    public  GameObject PlayWj; //小马里奥
    public  GameObject HUQ; //加载火球
    public static GameObject HUQ2; //火球

    float tf;

    void Start ()
    {

         //Hp.PlayerHp = 1;//血量初始值为1
         wanjia = "Mario";
      
        ani = GetComponent<Animator>();//获取动画控制器组件
        spr = GetComponent<SpriteRenderer>();//获取精灵组件
        rig = GetComponent<Rigidbody2D>();//获取刚体组件
        isGround = true;
        PlayWj = (GameObject)Resources.Load("Mario");
        HUQ = (GameObject)Resources.Load("HuoQ");

        tf = 1;
    }
	
	void Update ()
    {
        Debug.Log(Hp.PlayerHp);

        f = Input.GetAxis("H");//按右为正，按左为负，不按为零

        if (Hp.PlayerHp > 0 && f != 0)
        {
            if (f < 0)//左走
            {
                spr.flipX = true;//反转
                hit = Physics2D.Raycast(transform.position,Vector2.left,0.1f,1 << 8);
            }
            else//右走
            {
                spr.flipX = false;//不反转
                hit = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, 1 << 8);
            }

            if (!hit.collider)//左右没有墙
            {
                transform.Translate(transform.right * 1.5f * Time.deltaTime * f);
            }
            ani.SetBool("IsRun",true);
        }
        
        if(f == 0)
        {
            ani.SetBool("IsRun", false);
        }

        //发射射线并获取射线碰撞到的物体信息：发射起点为玩家自身坐标原点，方向为向下，射线长度为0.1f，只检测第8层
        dhit = Physics2D.Raycast(transform.position, Vector2.down, aaa, 1 << 8);
        if (dhit.collider)//射线碰到物体的碰撞器
        {
            isGround = true;
            ani.SetBool("IsJump", false);
        }
        else
        {
            isGround = false;
            ani.SetBool("IsJump", true);
        }

        //跳
        if (Input.GetKeyDown(KeyCode.Space) && isGround)//按下空格
        {
            rig.AddForce(Vector2.up * 200);
            AudioManager.Instance.PlaySound("跳");
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            HUQ2 = Instantiate(HUQ, transform.position, Quaternion.identity);
            HuoQ.FS2();

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            HUQ2 = Instantiate(HUQ, transform.position, Quaternion.identity);
            HuoQ.FS1();
        }

        if (gameObject.tag =="WuDi")
        {
            tf -= Time.deltaTime;

            if (tf <= 0)
            {
                gameObject.tag = "Player";
                tf = 1;
            }
        }
	}

    public void playdeth() //人物死亡
    {
        Hp.PlayerHp--;


        if(Hp.PlayerHp <= 0)
        {
            ani.SetTrigger("IsDead");
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlaySound("死亡1");
            Invoke("Deth2",0.8f);
            Destroy(GetComponent<BoxCollider2D>()); //销毁组件
            rig.velocity = Vector2.zero; //速度归零 保护措施

            rig.AddForce(Vector2.up * 150); //死亡向上跳一下

            //Destroy(gameObject, 3);

        }

         if(Hp.PlayerHp == 1 && wanjia == "Mario")
        {
            GameObject da = GameObject.Find("Mario2");
            da.SetActive(false);
            GameObject obj = Instantiate(PlayWj, transform.position, Quaternion.identity);

            obj.tag = "WuDi";

            obj.name = "Mario";
            PlayerControl.wanjia = obj.name;

            CameraControl.mario = obj.transform;

            Destroy(da);

            AudioManager.Instance.PlaySound("吃到蘑菇或花");
        }
    }

    void Deth2() //死亡2音效
    {
        AudioManager.Instance.PlaySound("死亡2");
    }
}

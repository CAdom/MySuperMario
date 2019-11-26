using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //血量
    public int Hp = 1;
    //钢体组件
    private Rigidbody2D rBody;
    //动画组件
    private Animator ani;
    //是否在地面
    public bool isGround;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void PlayDieSound2()
    {
        AudioManager.Instance.PlaySound("死亡2");
    }
    void Update()
    {
        if (Hp <= 0)
        {
            return;
        }
        //移动
        //水平轴  -1(left)  0  1(right)
        float horizontal = Input.GetAxis("Horizontal");         //浮点类型控制渐变

        if (horizontal != 0)
        {
            //移动
            Vector2 v = rBody.velocity;       //获取速度
            v.x = horizontal * 1;
            rBody.velocity = v;
            //转向
            GetComponent<SpriteRenderer>().flipX = horizontal > 0 ? false : true;
            //播放跑步动画
            ani.SetBool("IsRun", true);
        }
        else
        {
            //停止
            //停止跑步动画
            ani.SetBool("IsRun", false);
        }
        //跳跃
        if(Input.GetKeyDown(KeyCode.X) && isGround)
        {
            //给一个向上的力
            rBody.AddForce(Vector2.up * 250);
            //播放跳跃声音
            AudioManager.Instance.PlaySound("跳");
        }
    }

    //进入触发  脚下踩了东西
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果踩到的是地面
        if(collision.tag=="Ground")
        {
            isGround = true;
            //停止播放跳跃动画
            ani.SetBool("IsJump",false);
        }
    }
    //离开触发  脚下离开东西
    private void OnTriggerExit2D(Collider2D collision)
    {
        //如果离开的是地面
        if (collision.tag == "Ground")
        {
            isGround = false;
            //播放跳跃动画
            ani.SetBool("IsJump", true);
        }
    }

    //如果碰到敌人
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Enemy")
        {
            Hp--;
            if(Hp<=0)
            {
                //播放死亡动画
                ani.SetTrigger("Die");
                //删除碰撞器
                Destroy(GetComponent<CapsuleCollider2D>());
                //静止
                rBody.velocity = Vector2.zero;
                //给玩家一个向上的力
                rBody.AddForce(Vector2.up * 200f);
                //停止播放地上声音
                AudioManager.Instance.StopSound();
                //播放死亡声音
                AudioManager.Instance.PlaySound("死亡1");
                //1s后播放死亡声音2
                Invoke("PlayDieSound2",1f);
                //加油
                //test1
                //test2
            }
        }
    }
}

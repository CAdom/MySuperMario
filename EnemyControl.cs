using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    int Hp;//敌人血量
    int dir;//敌人移动的方向
    RaycastHit2D hit;
    Animator ani;

    void Start ()
    {
        Hp = 1;
        dir = -1;

        ani = gameObject.GetComponent<Animator>();
    }
	
	void Update ()
    {      if(Hp > 0)
        {
            transform.Translate(transform.right * 0.2f * Time.deltaTime * dir);
        }

        if (dir == 1)
        {
            hit = Physics2D.Raycast(transform.position +Vector3.up*0.1f, Vector2.right, 0.1f, ~(1 << 9));
        }
        else if (dir == -1)
        {
            hit = Physics2D.Raycast(transform.position+ Vector3.up * 0.1f, Vector2.left, 0.1f, ~(1 << 9));
        }

        if (hit.collider)
        {
            dir = -dir;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = -dir;
        if(collision.collider.tag == "Player")
        {
            if(collision.contacts[0].normal == Vector2.down) //contacts数组代表接触点 第0个点。 normal:接触点垂直的法线。
            {

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                Emdeth();

            }
            else
            {
                collision.gameObject.GetComponent<PlayerControl>().playdeth(); //拿到碰撞人物 获取人物绑定的脚本，在调用方法。
            }
           
        }
   
    
    }
     
    private void OnTriggerEnter2D(Collider2D collision) //火球攻击
    {
        if (collision.tag == "TouSW")
        {
            Emdeth();
        }
    }


    void Emdeth() //敌人死亡
    {
        Hp--;
        if (Hp <= 0)
        {
            Destroy(gameObject,0.6f); //在0.6秒以后执行销毁。Destroy并不是立即销毁（在本帧结束之前），第二帧开始之前才会销毁。
            ani.SetTrigger("emenydeth");
            AudioManager.Instance.PlaySound("踩敌人");

            GetComponent<Collider2D>().enabled = false; //关闭组件（未激活）
            Destroy(GetComponent<Rigidbody2D>()); //销毁组件


        }
    }


}

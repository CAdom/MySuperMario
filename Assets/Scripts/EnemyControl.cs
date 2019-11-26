using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    //血量
    public int Hp = 1;
    //方向
    private int dir = 1;
    //动画
    private Animator ani; 
	
	void Start () {
        ani = GetComponent<Animator>();
	}

	void Update () {
		if(Hp<=0)
        {
            return;
        }
        //移动
        transform.Translate(Vector2.right * dir * 0.2f * Time.deltaTime);
	}

    //发生碰撞调头
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //反方向
        dir = -dir;
    }

    //如果进入玩家的触发，证明在玩家脚下
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Hp--;
            if(Hp<=0)
            {
                //死亡
                Destroy(gameObject, 1f);
                //播放死亡音乐
                AudioManager.Instance.PlaySound("踩敌人");
                //给玩家一个向上的力
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
                //死亡动画
                ani.SetTrigger("Die");
                //删除敌人身上的物理组件
                Destroy(GetComponent<Collider2D>());
                Destroy(GetComponent<Rigidbody2D>());
            }
        }
    }
}

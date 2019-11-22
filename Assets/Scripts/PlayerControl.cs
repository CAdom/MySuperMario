using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    //血量
    public int Hp = 1;
    //钢体组件
    private Rigidbody2D rBody;
    //动画组件
    private Animator ani;

	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
	}
	
	
	void Update () {
		if(Hp <= 0)
        {
            return;
        }
        //移动
        //水平轴  -1(left)  0  1(right)
        float horizontal = Input.GetAxis("Horizontal");         //浮点类型控制渐变
       
        if(horizontal!=0)
        {
            //移动
            Vector2 v=rBody.velocity;       //获取速度
            v.x = horizontal * 1;
            rBody.velocity = v;
            //转向
            GetComponent<SpriteRenderer>().flipX = horizontal > 0 ? false : true;
            //播放跑步动画

        }
        else
        {
            //停止

        }
	}
}

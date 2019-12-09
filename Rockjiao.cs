using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockjiao : MonoBehaviour
{
    Transform[] rockTra;


    void Start ()
    {
        rockTra = transform.GetComponentsInChildren<Transform>(); //获取所有子物体里面的Transform组件（包括绑定脚本的父物体）。 

    }
	

	void Update ()
    {
		
	}

    //碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.contacts[0].normal == Vector2.up)
        {

            AudioManager.Instance.PlaySound("顶破砖");

            Destroy(gameObject);
            foreach (Transform item in rockTra)
            {
                if(item.name.Contains("rock0_0")) //名称包含
                {
                    item.transform.parent = null;   //清除父物体链接
                    Rigidbody2D rig = item.gameObject.AddComponent<Rigidbody2D>();

                   Vector2 ff = item.position - transform.position + Vector3.up * 0.3f;  //小砖块中心减去父物体的位置来获得方向

                    rig.AddForce(ff * 500f);
                    Destroy(item.gameObject,1); //销毁小物体



                }
       

            }


        }
        
    }

}

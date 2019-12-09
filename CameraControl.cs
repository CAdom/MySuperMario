using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float minX;
    float maxX;
   public static Transform mario;

	void Start ()
    {
        minX = -16;
        maxX = 16;
        mario = GameObject.Find(PlayerControl.wanjia).transform;
    }
	
	void Update ()
    {
        //mario = GameObject.Find(PlayerControl.wanjia).transform;
        Vector3 pos = transform.position;//获取相机当前的位置
        pos.x = mario.position.x;//更改位置的X轴的位置
        if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        if (pos.x < minX)
        {
            pos.x = minX;
        }

        transform.position = pos;//将更改后的值重新附给相机，实现相机位置更新
	}
}

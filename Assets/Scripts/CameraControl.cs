using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    //跟随目标
    public Transform Target;
    //边界
    public float MinX;      //最小边界
    public float MaxX;      //最大边界
	void Start () {
		
	}

	void Update () {
        //获取当前摄像机位置
        Vector3 v = transform.position;
        //更新相机的位置
        v.x = Target.position.x;
        //判断边界
        if(v.x>MaxX)
        {
            v.x = MaxX;
        }
        else if(v.x<MinX)
        {
            v.x = MinX;
        }
        //赋值回来
        transform.position = v;
	}
}

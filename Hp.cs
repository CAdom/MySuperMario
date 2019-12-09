using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{

    public static int PlayerHp;
    public static Text UI_JB;
    public static int jf;

    // Use this for initialization
    void Start ()
    {

        PlayerHp = 1;
        jf = 0;

         UI_JB = GameObject.Find("JiFen_1").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () 
    {
        UI_JB.text = "当前积分:" + jf; //数据更新
    }
}

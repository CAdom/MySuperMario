using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Script_Login : MonoBehaviour {
    string txt_ID;
    string txt_Psw;
    Text txt_info;
    string filePath;

	// Use this for initialization
	void Start () {
        txt_info = GameObject.Find("Txt_Info").GetComponent<Text>();
        filePath = Application.dataPath + "/" + "users.txt";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //********************************************
    public void Login()
    {
        txt_ID = GameObject.Find("AccountInput/Text").GetComponent<Text>().text;
        txt_Psw = GameObject.Find("PasswordInput/Text").GetComponent<Text>().text;
        if (txt_ID == "")
        {
            txt_info.text = "请输入账号";
            return;
        }
        if (txt_Psw == "")
        {
            txt_info.text = "请输入密码";
            return;
        }

        if (Check_Login(txt_ID, txt_Psw))
        {
            txt_info.text = "登录成功";
        }
        else
        {
            txt_info.text = "账号或密码错误";
        }
    }
    bool Check_Login(string id, string psw)
    {
        string[] Users = File.ReadAllLines(filePath);
        for (int i = 0; i < Users.Length; i++)
        {
            string user_id = Users[i].Split(' ')[0];
            string user_psw = Users[i].Split(' ')[1];
            if (id == user_id && psw == user_psw)
            {
                return true;
            }
        }
        return false;
    }
}

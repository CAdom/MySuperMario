using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Script_Regist : MonoBehaviour {
    string txt_ID;
    string txt_Psw;
    string txt_Psw_2;
    bool b_IfLoginSuccess;
    Text txt_info;
    string filePath;
    StreamWriter sw;

    // Use this for initialization
    void Start () {
        txt_info = GameObject.Find("Txt_Info").GetComponent<Text>();
        filePath = Application.dataPath + "/" + "users.txt";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Regist()
    {
        txt_ID = GameObject.Find("InputF_ID/Text").GetComponent<Text>().text;
        txt_Psw = GameObject.Find("InputF_Psw/Text").GetComponent<Text>().text;
        txt_Psw_2 = GameObject.Find("InputF_Psw_2/Text").GetComponent<Text>().text;
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
        if (txt_Psw_2 == "")
        {
            txt_info.text = "请输入密码";
            return;
        }

        if (txt_Psw != txt_Psw_2)
        {
            txt_info.text = "两次输入的密码不一致";
        }
        else
        {
            if (CheckID(txt_ID) == false)
            {
                txt_info.text = "已存在相同账号";
            }
            else
            {
                txt_info.text = "注册成功";
                //
                WriteUserInfo(txt_ID, txt_Psw);
            }
        }
    }

    void WriteUserInfo(string id, string psw)
    {
        if (!File.Exists(filePath))
        {
            sw = File.CreateText(filePath);
        }

        sw = File.AppendText(filePath);
        sw.WriteLine(id + " " + psw);
        sw.Close();
    }

    bool CheckID(string id)
    {
        string[] Users = File.ReadAllLines(filePath);
        for (int i = 0; i < Users.Length; i++)
        {
            string user_id = Users[i].Split(' ')[0];
            //string user_psw = Users[i - 1].Split( )[1];
            if (id == user_id)
            {
                return false;
            }
        }
        return true;
    }
}

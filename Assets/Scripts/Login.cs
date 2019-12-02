using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public InputField AccountInput;//账号输入
    public InputField PasswordInput;//密码输入
    public Text Mistake;//账号及密码输入错误提示
    public Text Register;//登录成功提示

    public string MySuperMario { get; private set; }

    public void OnButton()//Button点击事件
    {
        string AccountNumber = AccountInput.text;//获取输入账号
        string PassWordNumber = PasswordInput.text;//获取输入密码
        if (AccountNumber == "2017301110107" && PassWordNumber == "123")//判断是否输入正确
        {
            Register.gameObject.SetActive(true);//登录效果提示
            StartCoroutine(Disappear());//调用协程
            SceneManager.LoadScene(MySuperMario);//跳转别的场景
        }
        else
        {
            Mistake.gameObject.SetActive(true);//账号密码输入错误提示
            StartCoroutine(Disappear());//调用协程
        }
    }
    IEnumerator Disappear()//协程
    {
        yield return new WaitForSeconds(2);//产生效果两秒
        Mistake.gameObject.SetActive(false);//提示错误效果消失
        Register.gameObject.SetActive(false);//提示登录成功效果消失
    }
    /*
        // Use this for initialization
        void Start () {
             DontDestroyOnLoad(this);
        }

        // Update is called once per frame
        void Update () {

        }
    */
}

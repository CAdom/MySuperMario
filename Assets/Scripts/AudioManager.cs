using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //获取声音播放组件 
    private AudioSource player;

    void Start()
    {
        Instance = this;            //创建静态自身对象
        //获取音频播放组件
        player = GetComponent<AudioSource>();
    }
    //播放音效
    public void PlaySound(string name)
    {
        //加载的音效
        AudioClip clip = Resources.Load<AudioClip>(name);
        //播放
        player.PlayOneShot(clip);
    }
    //停止播放声音
    public void StopSound()
    {
        player.Stop();
    }
}

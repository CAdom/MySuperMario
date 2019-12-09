using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    GameObject obj;
    AudioSource bgmPlayer;
    AudioSource sePlayer;

    //单例模式
    public static AudioManager Instance;//声明当前类静态实例
    private void Awake()
    {
        Instance = this;//this就代表当前这个类
    }

    void Start ()
    {
        obj = GameObject.Find("AudioPlayer");
        bgmPlayer = obj.GetComponent<AudioSource>();
        sePlayer = obj.GetComponent<AudioSource>();
    }

    public void PlayMusic(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audios/" + name);//加载音乐片段
        bgmPlayer.clip = clip;//切换音乐
        bgmPlayer.Play();//播放新的音乐
    }

    public void StopMusic()
    {
        bgmPlayer.Stop();
    }

    public void PlaySound(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audios/" + name);//加载特效片段
        sePlayer.PlayOneShot(clip);//播放加载的音频
    }
}

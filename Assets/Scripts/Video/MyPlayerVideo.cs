using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MyPlayerVideo : VideoCall
{
    [SerializeField]
    PlayImg play,stop;
    [SerializeField]
    Slider topBar;
    [SerializeField]
    Image maskImg;
    
    public bool isStop = true;
    bool isNowTime; //�V�ƻP��e�ɶ��ۦP
    long frameTimeCount; //�V�ƭp��
    ulong allVideoLength; //�v���`�V��
    float barValue;
    bool isVideoStart = false; //�w�g�}�l����

    private void Awake()
    {
        Init();
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate 
        {
            Play();
        });
    }

    void Update()
    {
        if (!isVideoStart && vp.frame > 0)
        {
            maskImg.gameObject.SetActive(false);
            isVideoStart = true;
            allVideoLength = vp.frameCount - 2;
        }
        if (!isStop)
        {
            CountBarTime();
        }
    }

    void Play()
    {
        if (!isStop)
        {
            isStop = true;
            barValue = topBar.value;
            vp.Pause();
            stop.Show();
        }
        else
        {
            if (barValue != topBar.value)
            {
                CalculateNowTime(topBar.value);
            }
            isStop = false;
            vp.Play();
            play.Show();
        }
    }
    public override void CallPlay()
    {
        if (!isStop)
        {
            isStop = true;
            barValue = topBar.value;
            vp.Pause();
        }
        else
        {
            if (barValue != topBar.value)
            {
                CalculateNowTime(topBar.value);
            }
            isStop = false;
            vp.Play();
        }
    }
    public void CalculateNowTime(float _v)
    {
        frameTimeCount = (long)((float)allVideoLength * _v);
        if (frameTimeCount >= (long)allVideoLength) return;
        if (!vp.isPlaying) vp.Play();
        vp.frame = frameTimeCount;
        isNowTime = true;
    }
    void CountBarTime()
    {
        if (isNowTime)
        {
            if (vp.frame == frameTimeCount)
            {
                isNowTime = false;
            }
            else
                return;
        }

        frameTimeCount = vp.frame;
        if (allVideoLength == 0)
        {
            topBar.value = 0;
            allVideoLength = vp.frameCount;
        }
        if (frameTimeCount >= (long)allVideoLength)
        {
            topBar.value = 1;
        }
        else
        {
            topBar.value = (float)frameTimeCount / (float)allVideoLength;
        }
    }
}

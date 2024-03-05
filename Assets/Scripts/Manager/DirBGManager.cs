using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirBGManager : MonoBehaviour
{
    [SerializeField]
    string dirId;
    [Header("���ɩ���ɶ�")]
    [SerializeField]
    float audioDelayTime;
    [Header("���񵲧��n���n�����_�_")]
    [SerializeField]
    bool noClose;
    [SerializeField]
    bool playOnStart = true;
    float timer = 1;
    bool isStartTimer;
    bool isPlayBabyShow;
    [SerializeField]
    VideoCall vc;
    public delegate void DirEndEvent();
    /// <summary>
    /// ���񧹨ƥ�
    /// </summary>
    public DirEndEvent _DirEndEvent;
    private void Start()
    {
        if (GetComponent<Button>() != null)
        {
            GetComponent<Button>().onClick.AddListener(delegate
            {
                StopDir();
                if (vc != null)
                    vc.CallPlay();
                if (_DirEndEvent != null)
                    _DirEndEvent.Invoke();
            });
        }
        if (playOnStart)
            PlayDir();
        else if (!noClose)
        {
            gameObject.SetActive(false);
            vc.CallPlay();
        }
    }

    private void Update()
    {
        if (isStartTimer)
            timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1;
            isPlayBabyShow = true;
            isStartTimer = false;
        }
        if (isPlayBabyShow && !noClose)
        {
            isPlayBabyShow = false;
            StartCoroutine(CoBabyShow());
        }
    }

    /// <summary>
    /// ���񤶲�
    /// </summary>
    public void PlayDir()
    {
        AudioManager.inst.PlaySFX(dirId, audioDelayTime);
        timer = AudioManager.inst.SFXTime(dirId);
        isStartTimer = true;
    }
    /// <summary>
    /// �����
    /// </summary>
    public void StopDir()
    {
        if (!noClose)
            gameObject.SetActive(false);

        AudioManager.inst.SFXStop(dirId);
    }

    IEnumerator CoBabyShow()
    {
        for (float f = 1; f >= 0; f -= 0.05f)
        {
            transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,f);
            yield return new WaitForSeconds(0.05f);
        }
        
        gameObject.SetActive(false);
        transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (vc != null)
            vc.CallPlay();
        if (_DirEndEvent != null)
            _DirEndEvent.Invoke();
    }
}

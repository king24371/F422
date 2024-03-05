using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class VideoCall : MonoBehaviour
{
    protected VideoPlayer vp;
    [SerializeField]
    string vpUrl;

    public void Init()
    {
        vp = GetComponent<VideoPlayer>();
        vp.url = Path.Combine(Application.streamingAssetsPath, vpUrl);
        //vp.Play();
    }

    public virtual void CallPlay()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGManager : MonoBehaviour
{
    public int sceneIndex = 0;
    [SerializeField]
    Button controlDirBtn;
    [SerializeField]
    Button dirBtn;
    [SerializeField]
    Image dirMask;
    [SerializeField]
    Button nextBtn;
    [SerializeField]
    Button backBtn;
    [SerializeField]
    int challengePage;
    [SerializeField]
    Button challengeBtn;
    [SerializeField]
    List<Sprite> pageNumberSprs = new List<Sprite>();
    [SerializeField]
    List<Sprite> blackNumberSprs = new List<Sprite>();
    [SerializeField]
    Image nowPageImg, allPageImg,blackNowPageImg,blackAllPageImg;
    AsyncOperation op;
    void Start()
    {
        sceneIndex = 0;
        if (nextBtn != null)
        {
            nextBtn.onClick.AddListener(delegate
            {
                if (op != null) return;
                LoadScene(1);
            });
        }
        if (backBtn != null)
        {
            backBtn.onClick.AddListener(delegate
            {
                if (op != null) return;
                LoadScene(-1);
            });
        }
        if (controlDirBtn != null)
        {
            controlDirBtn.gameObject.SetActive(true);
            controlDirBtn.onClick.AddListener(delegate
            {
                controlDirBtn.gameObject.SetActive(false);
                dirMask.gameObject.SetActive(true);
                dirBtn.gameObject.SetActive(true);
            });
        }
        if (dirBtn != null)
        {
            dirMask.gameObject.SetActive(false);
            dirBtn.gameObject.SetActive(false);
            dirBtn.onClick.AddListener(delegate
            {
                dirMask.gameObject.SetActive(false);
                dirBtn.gameObject.SetActive(false);
                controlDirBtn.gameObject.SetActive(true);
            });
        }
        if (challengeBtn != null)
        {
            challengeBtn.gameObject.SetActive(false);
            challengeBtn.onClick.AddListener(delegate 
            {
                if (op != null) return;
                LoadScene(1);
            });
        }
        allPageImg.sprite = pageNumberSprs[SceneManager.sceneCountInBuildSettings - 2];
        blackAllPageImg.sprite = blackNumberSprs[SceneManager.sceneCountInBuildSettings - 2];
        LoadScene(1);
    }
    public void LoadScene(int index)
    {
        AudioManager.inst.SFXStop();
        if (sceneIndex + index >= SceneManager.sceneCountInBuildSettings) return;

        StartCoroutine(CoLoading(index));
    }
    IEnumerator CoLoading(int index)
    {
        op = SceneManager.LoadSceneAsync(sceneIndex + index, LoadSceneMode.Additive);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            if (op.progress >= 0.9f)
                op.allowSceneActivation = true;
            yield return null;
        }

        op = null;
        //是否卸載場景判定(Menu不能卸載)
        if (sceneIndex != 0)
            SceneManager.UnloadSceneAsync(sceneIndex);
        if(sceneIndex - 2>=0)
            dirMask.transform.GetChild(sceneIndex - 2).gameObject.SetActive(false);
        sceneIndex += index;
        //頁碼圖片交換
        nowPageImg.sprite = pageNumberSprs[sceneIndex - 1];
        blackNowPageImg.sprite = blackNumberSprs[sceneIndex - 1];
        //挑戰鈕開關
        if (challengeBtn != null)
        {
            if (sceneIndex == challengePage)
                challengeBtn.gameObject.SetActive(true);
            else
                challengeBtn.gameObject.SetActive(false);
        }
        //說明區開關設定
        if (sceneIndex == 1)
        {
            nextBtn.gameObject.SetActive(true);
            backBtn.gameObject.SetActive(false);
            controlDirBtn.gameObject.SetActive(false);
            dirBtn.gameObject.SetActive(false);
        }
        else if (sceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextBtn.gameObject.SetActive(false);
            backBtn.gameObject.SetActive(true);
            if (dirBtn.gameObject.activeSelf)
                controlDirBtn.gameObject.SetActive(false);
            else
                controlDirBtn.gameObject.SetActive(true);
            dirMask.transform.GetChild(sceneIndex - 2).gameObject.SetActive(true);
        }
        else
        {
            nextBtn.gameObject.SetActive(true);
            backBtn.gameObject.SetActive(true);
            if (dirBtn.gameObject.activeSelf)
                controlDirBtn.gameObject.SetActive(false);
            else
                controlDirBtn.gameObject.SetActive(true);
            dirMask.transform.GetChild(sceneIndex - 2).gameObject.SetActive(true);
        }
    }
}

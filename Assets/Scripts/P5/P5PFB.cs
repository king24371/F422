using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P5PFB : MonoBehaviour
{
    public Text Time, Eight, Five, Three;
    public P7SelectCard Pon8, Pon5, Pon3;

    public void fillNum(int T, int E, int F, int Th)
    {
        Time.text = T.ToString();
        Eight.text = E.ToString();
        Five.text = F.ToString();
        Three.text = Th.ToString();
    }

    public void setVolume()
    {
        int e = int.Parse(Eight.text);
        int f = int.Parse(Five.text);
        int th = int.Parse(Three.text);
        Pon8.setVolume(e);
        Pon5.setVolume(f);
        Pon3.setVolume(th);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P7Target : MonoBehaviour
{
    public P7SelectCard p7Select;

    public void pourAnim(int liter, Transform trans)
    {
        switch (liter)
        {
            case 3:
                trans.position = p7Select.Pon3.position;
                trans.localEulerAngles = new Vector3(0, 0, -101);
                trans.GetComponent<Animator>().enabled = true;
                break;
            case 5:
                trans.position = p7Select.Pon5.position;
                trans.localEulerAngles = new Vector3(0, 0, -101);
                trans.GetComponent<Animator>().enabled = true;
                break;
            case 8:
                trans.position = p7Select.Pon8.position;
                trans.localEulerAngles = new Vector3(0, 0, -101);
                trans.GetComponent<Animator>().enabled = true;
                break;
            case 7:
                trans.position = p7Select.Pon5.position;
                trans.localEulerAngles = new Vector3(0, 0, -101);
                trans.GetComponent<Animator>().enabled = true;
                break;
            case 10:
                trans.position = p7Select.Pon8.position;
                trans.localEulerAngles = new Vector3(0, 0, -101);
                trans.GetComponent<Animator>().enabled = true;
                break;
        }
    }

    public int calcPour(int V)
    {
        int diff = 0;
        if (p7Select.Volume == 0)
        {
            if (V >= p7Select.Liter)
            {
                diff = V - p7Select.Liter;
                p7Select.Volume = p7Select.Liter;
                p7Select.addOil(0, p7Select.Liter);
            }
            else
            {
                diff = 0;
                p7Select.Volume = V;
                p7Select.addOil(0, V);
            }
            
            return diff;
        }
        else
        {
            diff = p7Select.Liter - p7Select.Volume;

            if (V >= diff)
            {
                diff = V - diff;
                p7Select.addOil(p7Select.Volume, p7Select.Liter);
                p7Select.Volume = V+p7Select.Volume;
                if (p7Select.Volume > p7Select.Liter)
                    p7Select.Volume = p7Select.Liter;
            }
            else
            {
                diff = 0;
                p7Select.addOil(p7Select.Volume,  V + p7Select.Volume);
                p7Select.Volume = V + p7Select.Volume;
                if (p7Select.Volume > p7Select.Liter)
                    p7Select.Volume = p7Select.Liter;
            }

            return diff;
        }
    }
}

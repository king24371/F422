using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5Target : MonoBehaviour
{
    public P5SelectCard p5Select;

    public void pourAnim(int c)
    {
        p5Select.pourOil(c);
    }

    public int calcPour(int V)
    {
        int diff = 0;
        if (p5Select.Volume == 0)
        {
            if (V >= p5Select.Liter)
            {
                diff = V - p5Select.Liter;
                p5Select.Volume = p5Select.Liter;
                p5Select.addOil(0, p5Select.Liter);
            }
            else
            {
                diff = 0;
                p5Select.Volume = V;
                p5Select.addOil(0, V);
            }
            
            return diff;
        }
        else
        {
            diff = p5Select.Liter - p5Select.Volume;

            if (V >= diff)
            {
                diff = V - diff;
                p5Select.addOil(p5Select.Volume, p5Select.Liter);
                p5Select.Volume = V+p5Select.Volume;
                if (p5Select.Volume > p5Select.Liter)
                    p5Select.Volume = p5Select.Liter;
            }
            else
            {
                diff = 0;
                p5Select.addOil(p5Select.Volume,  V + p5Select.Volume);
                p5Select.Volume = V + p5Select.Volume;
                if (p5Select.Volume > p5Select.Liter)
                    p5Select.Volume = p5Select.Liter;
            }

            return diff;
        }
    }
}

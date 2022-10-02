using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickControl : MonoBehaviour
{
    private int index = 4;
    public GameObject bar;
    public GameObject gameC;
    public int targetIndex = 0;
    private Color c2;
    GameController gctrl;
    void Start()
    {
        c2 = new Color(0.99f, 0.92f, 0.73f);
        gctrl = gameC.GetComponent<GameController>();
    }

    private void OnMouseDown()
    {
        if(index != targetIndex) 
        {           
            index += 1;
            if (index >= gctrl.bars.Length)
                index %= gctrl.bars.Length;
            bar.GetComponent<SpriteRenderer>().sprite = gameC.GetComponent<GameController>().bars[index];
            if (index == targetIndex) 
            { 
                bar.GetComponent<SpriteRenderer>().color = c2;
                gctrl.correctNum += 1;
            }
        }
    }
    public void ScriptedChange()
    {
        index = 0;
        if (index >= gctrl.bars.Length)
            index %= gctrl.bars.Length;
        bar.GetComponent<SpriteRenderer>().sprite = gameC.GetComponent<GameController>().bars[index];
        if (index == targetIndex)
        {
            bar.GetComponent<SpriteRenderer>().color = c2;
            gctrl.correctNum += 1;
        }
    }
}

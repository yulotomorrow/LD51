using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIndicator : MonoBehaviour
{
    public float delay = 7.5f;
    private SpriteRenderer sr;
    private Color cl;
    void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        cl = sr.color;
        StartCoroutine(HidePoints());
    }

    IEnumerator HidePoints() 
    {
        yield return new WaitForSecondsRealtime(delay);
        while (true) 
        { 
            sr.color = new Color(cl.r, cl.g, cl.b, 1);
            for (float a = 1; a > 0; a -= 0.05f) 
            {
                sr.color = new Color(cl.r, cl.g, cl.b, a);
                yield return new WaitForSecondsRealtime(0.05f);
            }
            sr.color = new Color(cl.r, cl.g, cl.b, 0);
            yield return new WaitForSecondsRealtime(9f);
        }
    }
}

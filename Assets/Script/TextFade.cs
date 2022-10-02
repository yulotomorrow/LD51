using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(FadeText());
    }
    IEnumerator FadeText() 
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}

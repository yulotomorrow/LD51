using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingScript : MonoBehaviour
{
    public GameObject aya;
    public Sprite[] ayaSp;
    public GameObject flute;
    public GameObject bg;
    public AudioClip answer;
    public AudioClip mainTheme;
    AudioSource au;
    void OnEnable()
    {
        au = GetComponent<AudioSource>();
        StartCoroutine(EndScript());
    }


    IEnumerator EndScript() 
    {
        for(int i = 0; i < 40; ++i) 
        {
            float step = (6.15f-1.75f) / 40f;
            aya.transform.position = new Vector2(0, -6.15f + i * step);
            yield return new WaitForSecondsRealtime(0.08f);
        }
        au.Stop();
        yield return new WaitForSecondsRealtime(1f);
        
        au.clip = answer;
        au.Play();
        yield return new WaitForSecondsRealtime(7.5f);
        flute.SetActive(true);
        yield return new WaitForSecondsRealtime(2.5f);
        aya.GetComponent<SpriteRenderer>().sprite = ayaSp[0];
        flute.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);        
        aya.GetComponent<SpriteRenderer>().sprite = ayaSp[1];
        au.clip = mainTheme;
        au.Play();
        yield return new WaitForSecondsRealtime(10f);
        for (int i = 0; i < 50; ++i)
        {
            bg.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i / 50f);
            yield return new WaitForSecondsRealtime(5f/50);
        }
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

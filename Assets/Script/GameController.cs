using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite[] bars;
    public AudioClip[] clips;
    public GameObject shade;
    public GameObject text;
    public int correctNum;
    public int totalNum = 4;
    public int[] sequence;
    private AudioSource au;
    private void OnEnable()
    {
        au = GetComponent<AudioSource>();
//        sequence = new int[] { 0, 1, 4, 10, 6, 10, 10, 10};
        StartCoroutine(PlaySong());
    }
    IEnumerator PlaySong() 
    {
        while (true) 
        { 
            foreach (int i in sequence)
            {
                if(i < 10)
                {
                    au.clip = clips[i];
                    au.Play();
                }
                yield return new WaitForSecondsRealtime(5f/8);
            }
            if(correctNum == totalNum)
                StartCoroutine(Fade());
            yield return new WaitForSecondsRealtime(5f);
        }
    }
    IEnumerator Fade()
    {
        text.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = "Correct!";
        SpriteRenderer sr2 = shade.GetComponent<SpriteRenderer>();
        for(float a = 1; a > 0; a -= 0.05f) 
        {
            sr2.color = new Color(0, 0, 0, 1 - a);
            yield return new WaitForSecondsRealtime(0.05f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CheckResult() 
    {
        correctNum = 0;
        text.GetComponent<TextMeshProUGUI>().text = "Wrong!";
        foreach (Transform child in transform) 
        {
            if (child.gameObject.GetComponent<ClickControl2>().isMatch == true)
                correctNum += 1;
        }
        if (correctNum == totalNum)
        {
            text.SetActive(true);
            text.GetComponent<TextMeshProUGUI>().text = "Correct!";
            StartCoroutine(Fade());
        }
        else
        {
            text.SetActive(true);
        }
    }
}
